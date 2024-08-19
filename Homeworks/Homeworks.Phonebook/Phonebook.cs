namespace phonebook;
internal class Phonebook
{
    private static Phonebook instance;
    private List<Abonent> abonents;
    private const string FilePath = "phonebook.txt";

    private Phonebook()
    {
        abonents = new List<Abonent>();
        LoadFromFile();
    }

    public static Phonebook Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Phonebook();
            }
            return instance;
        }
    }

    public void AddAbonent(string name, string phoneNumber)
    {
        if (this.abonents.Any(a => a.PhoneNumber == phoneNumber))
        {
            Console.WriteLine("Абонент с таким номером уже существует.");
            return;
        }

        var abonent = new Abonent(name, phoneNumber);
        this.abonents.Add(abonent);
        SaveToFile();
    }

    public void RemoveAbonent(string phoneNumber)
    {
        var abonent = this.abonents.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
        if (abonent != null)
        {
            this.abonents.Remove(abonent);
            SaveToFile();
        }
        else
        {
            Console.WriteLine("Абонент с таким номером не найден.");
        }
    }

    public Abonent? GetAbonentByPhoneNumber(string phoneNumber)
    {
        return this.abonents.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
    }

    public string? GetPhoneNumberByName(string name)
    {
        var abonent = this.abonents.FirstOrDefault(a => a.Name == name);
        return abonent?.PhoneNumber;
    }

    private void LoadFromFile()
    {
        if (File.Exists(FilePath))
        {
            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    this.abonents.Add(new Abonent(parts[0], parts[1]));
                }
            }
        }
    }

    private void SaveToFile()
    {
        var lines = this.abonents.Select(a => $"{a.Name},{a.PhoneNumber}");
        File.WriteAllLines(FilePath, lines);
    }
}