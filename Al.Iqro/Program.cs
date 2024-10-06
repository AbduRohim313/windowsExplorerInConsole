using System.Diagnostics;

var turganPath = Path.Combine();
string ildiz = null;
string papka = null;
List<string> papkalar = new List<string>();
List<string> filelar = new List<string>();

Bowlaw(IldizlarniOliw());

List<DriveInfo> IldizlarniOliw() => 
    DriveInfo.GetDrives().ToList();


List<string> PapkalarniOliw(string path) =>
    Directory.GetDirectories(path).ToList();


List<string> FilelarniOliw(string path) =>
    Directory.GetFiles(path).ToList();


string Kesiw(string path)
{
    for (int i = path.Length - 1; i >= 0; i--)
        if (path[i].ToString() == @"\")
            return path.Substring(0, i);
    return null;
}

string OxiriniKesiw(string papka, string path) => 
    papka.Substring(path.Length);


void Orqaga() =>
    Console.WriteLine("\t\t -1. orqaga");

void PapkagaTanlaw(string path)
{
    Console.Clear();
    short amalSanoqi = 0;
    short sanoq = 0;
    papkalar = PapkalarniOliw(path + @"\");
    filelar = FilelarniOliw(path);
    Console.WriteLine($"Joyingiz:\n\t{path}\n");
    foreach (var papka1 in papkalar)
    {
        Console.Write($"\t\t{sanoq++}. ");
        Console.WriteLine(OxiriniKesiw(papka1, path));
    }
    FilelarniKorsatiw(sanoq, filelar, path);
    Orqaga();
    int amal;
    Console.Write("\n >>>");

    try
    {
        amal = int.Parse(Console.ReadLine());
        if (amal == -1)
        {
            turganPath = Kesiw(path);
            if (turganPath.Length == 2)
            {
                // PapkagaTanlaw(turganPath);
                Bowlaw(IldizlarniOliw());
                return;
            }

            PapkagaTanlaw(turganPath);
            return;
        }

        if (papkalar == null)
        {
            if (amal > 0)
            {
                PapkagaTanlaw(turganPath);
                // Bowlaw(IldizlarniOliw());
                return;
            }

            return;
        }
    }
    catch (Exception e)
    {
        Xato();
        turganPath = Kesiw(path);
        if (turganPath.Length == 2)
            Bowlaw(IldizlarniOliw());
            // PapkagaTanlaw(turganPath);

        PapkagaTanlaw(turganPath);
        return;
    }


    if (amal >= papkalar.Count)
    {
        try
        {
            // Открываем изображение с использованием программы по умолчанию
            Process.Start(new ProcessStartInfo
            {
                FileName = filelar[amal - papkalar.Count],
                UseShellExecute = true
            });

            Console.WriteLine($"Изображение {filelar[amal - papkalar.Count]} успешно открыто.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }

        Console.WriteLine("\nDavom ettiriw uchun istalgan tugmani bosing...");
        Console.ReadKey();
        PapkagaTanlaw(path);
        return;
    }

    papka = papkalar.ElementAt(amal);

    Console.WriteLine(papka);
    turganPath = papka;
    PapkagaTanlaw(turganPath);
}

void FilelarniKorsatiw(short son, List<string> filelar, string path)
{
    foreach (var file in filelar)
    {
        Console.Write($"\t\t{son++}. ");
        Console.WriteLine(OxiriniKesiw(file, path));
    }
}

void XatoMenu()
{
    Console.WriteLine("\nDavom ettiriw uchun istalgan tugmani bosing...");
    Console.ReadKey();
    Bowlaw(IldizlarniOliw());
}

void Xato()
{
    Console.WriteLine("\nDavom ettiriw uchun istalgan tugmani bosing...");
    Console.ReadKey();
    PapkagaTanlaw(turganPath);
}

void Bowlaw(List<DriveInfo> ildizlar)
{
    short amalSanoqi = 0;
    Console.Clear();
    Console.WriteLine("\n\n");
    foreach (var VARIABLE in ildizlar)
        Console.WriteLine($"{amalSanoqi++}. {VARIABLE.Name}");

    short amal;
    Console.WriteLine(" -1. orqaga");
    Console.Write("\n>>>");
    try
    {
        amal = short.Parse(Console.ReadLine());
        if (amal > IldizlarniOliw().Count)
        {
            XatoMenu();
            return;
        }
    }
    catch (Exception e)
    {
        XatoMenu();
        return;
    }

    if (amal == -1)
        return;

    PapkagaTanlaw(Path.Combine(ildizlar[amal].Name));
}