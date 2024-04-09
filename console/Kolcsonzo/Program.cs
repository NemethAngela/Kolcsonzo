using MySqlConnector;

if (args.Count() != 2)
{
    Console.WriteLine("A program helyes paraméterezése: Kolcsonzo.exe c:\\kolcsonzok.csv c:\\kolcsonzesek.csv");
    Console.ReadKey();
}
else
{
    Console.WriteLine("A megadott fájlok: " + args[0] + ", " + args[1]);

    if (!File.Exists(args[0]))
    {
        Console.WriteLine("Az első paraméterben megadott fájl nem létezik: " + args[0]);
        Console.ReadKey();
        return;
    }
    if (!File.Exists(args[1]))
    {
        Console.WriteLine("Az második paraméterben megadott fájl nem létezik: " + args[1]);
        Console.ReadKey();
        return;
    }

    try
    {
        ProcessFile1();
        ProcessFile2();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Hiba a feldolgozás során: " + ex);
    }

    Console.ReadKey();
}

void ProcessFile1()
{
    string tartalom = File.ReadAllText(args[0]);
    int sorokSzama = 0;

    string connectionString = "server=localhost;user=root;password=titok;database=kolcsonzo";
    using MySqlConnection connection = new MySqlConnection(connectionString);
    connection.Open();

    var sorok = tartalom.Split(Environment.NewLine);

    string sql = "DELETE FROM kolcsonzesek";
    using MySqlCommand del1Cmd = new MySqlCommand(sql, connection);
    del1Cmd.ExecuteNonQuery();
    sql = "DELETE FROM kolcsonzok";
    using MySqlCommand del2Cmd = new MySqlCommand(sql, connection);
    del2Cmd.ExecuteNonQuery();

    for (int i = 1; i < sorok.Length; i++)
    {
        var ertekek = sorok[i].Split(";");
        // SQL parancs előkészítése
        sql = "INSERT INTO kolcsonzok (id, nev, szulido) VALUES (@Value1, @Value2, @Value3)";
        using MySqlCommand insertCmd = new MySqlCommand(sql, connection);
        insertCmd.Parameters.AddWithValue("@Value1", i);
        insertCmd.Parameters.AddWithValue("@Value2", ertekek[0]);
        insertCmd.Parameters.AddWithValue("@Value3", ertekek[1]);
        // Parancs végrehajtása
        insertCmd.ExecuteNonQuery();
        sorokSzama++;
    }

    Console.WriteLine("Az importálás sikerees volt, sorok száma: " + sorokSzama);

    connection.Close();
}

void ProcessFile2()
{
    string tartalom = File.ReadAllText(args[1]);
    int sorokSzama = 0;

    string connectionString = "server=localhost;user=root;password=titok;database=kolcsonzo";
    using MySqlConnection connection = new MySqlConnection(connectionString);
    connection.Open();

    var sorok = tartalom.Split(Environment.NewLine);

    string sql = "DELETE FROM kolcsonzesek";
    using MySqlCommand delCmd = new MySqlCommand(sql, connection);
    delCmd.ExecuteNonQuery();

    for (int i = 1; i < sorok.Length; i++)
    {
        var ertekek = sorok[i].Split(";");
        if (ertekek.Length != 4)
            break;

        // SQL parancs előkészítése
        sql = "INSERT INTO kolcsonzesek (kolcsonzokId, iro, mufaj, cim) VALUES (@Value1, @Value2, @Value3, @Value4)";
        using MySqlCommand insertCmd = new MySqlCommand(sql, connection);
        insertCmd.Parameters.AddWithValue("@Value1", ertekek[0]);
        insertCmd.Parameters.AddWithValue("@Value2", ertekek[1]);
        insertCmd.Parameters.AddWithValue("@Value3", ertekek[2]);
        insertCmd.Parameters.AddWithValue("@Value4", ertekek[3]);
        // Parancs végrehajtása
        insertCmd.ExecuteNonQuery();
        sorokSzama++;
    }

    Console.WriteLine("Az importálás sikerees volt, sorok száma: " + sorokSzama);

    connection.Close();
}