GemsCLI
========

Library for parsing command line arguments.

## Different Parameter Styles

Different parser options cab be used that suite the style of the developer.

- *Basic* style example; `C:\>example.com -help -debug=on document.txt`
- *Linux* style example; `C:\>example.com --help --debug=on document.txt`
- *Windows* style example; `C:\>example.com /help /debug=on document.txt`

The different styles are purely cosmetic and configurable.

## Named And Passed Parameters

Library supports two kinds of parameters. 

- *Named* parameters are values prefixed by an indentifying name.
- *Passed* parameters are values indentified by their numeric order of appearance.

In the following example

	C:\>example.com /debug document.txt

The argument `/debug` is a *Named* parameter, and the argument `document.txt` is a *Passed* parameter.

*Named* parameters can have a value assigned with an assignment character `=`, whereas *Passed* parameters always have a value.

An example of a *Named* parameter with a value;

	C:\>example.com /debug=off document.txt

*Named* parameter `debug` contains the value `off`, and the first *Passed* parameter contains the value `document.txt`.

## Order Of Required And Optional Parameters

*Named* parameters can appear on the command line in any order. Including before and after *Passed* parameters. As long as there are no optional *Passed* parameters. If the parser is configured to accept optional *Passed* parameters, then all *Named* parameters must appear before any *Passed* parameters.

	C:\>example.com /debug=off document.txt
	C:\>example.com document.txt /debug=off

Both variations are allowed, but if a second *Passed* parameter is defined as optional. Only the following examples are allowed.

	C:\>example.com /debug=off document.txt
	C:\>example.com /debug=off document.txt optional.txt

*Passed* parameters are taken in the order they appear on the command line. All required *Passed* parameters must appear before optional *Passed* parameters. This is how the parser knows if any required *Passed* parameters are missing.

## Just The Request Object

At it's most basic form the library can be used to create a `GemsCLI.Request` object. To give developers unrestricted access to the command line parameters as string data.

To create a request object;

	public static void Main(string[] args)
	{
		Request request = RequestFactory.Create(ParserOptions.WindowsStyle, args);

		foreach(ArgumentValue arg in request.Named)
		{
			Console.log(string.Format("Name: {0} Value: {1}", arg.Name, arg.Value);
		}

		foreach(ArgumentValue arg in request.Passed)
		{
			Console.log(string.Format("Value: {0}", arg.Value);
		}
	}

## Parameters As Typed Data

