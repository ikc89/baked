﻿namespace Do;

sealed class Banner
{
    public static void Print()
    {
        var assembly = typeof(Banner).Assembly;
        var version = assembly.GetName().Version!;
        var ver = $"{version.Major}.{version.Minor}.{version.Build}";

        var brand = ConsoleColor.DarkRed;
        var white = ConsoleColor.White;
        var foreground = ConsoleColor.Gray;
        var border = ConsoleColor.DarkGray;

        L("----------------------------------------------", border);
        L();
        W("  "); W("██", brand); L("        ████████    ██████████", white);
        W("    "); W("██", brand); L("      ██      ██  ██      ██", white);
        W("      "); W("██", brand); L("    ██      ██  ██      ██", white);
        W("    "); W("██", brand); L("      ██      ██  ██      ██", white);
        W("  "); W("██", brand); W("        ████████    ██████████  ", white); L("██████████", brand);
        L();
        L("------------------- v$VER$ -------------------".Replace("$VER$", ver), border);
        L();
        L("Docs: https://do.mouseless.codes", foreground);
        L("Source: https://github.com/mouseless/do", foreground);
        L();
        L("----------------------------------------------", border);
    }

    static void L(string? message = default, ConsoleColor? color = default) => W($"{message ?? string.Empty}{Environment.NewLine}", color);
    static void W(string message, ConsoleColor? color = default)
    {
        color ??= Console.ForegroundColor;

        var old = Console.ForegroundColor;

        Console.ForegroundColor = color.Value;
        Console.Write(message);

        Console.ForegroundColor = old;
    }
}
