using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AccountsManagerApp.Logic;

public class AccountRepository
{
    private const string FilePath = @"C:\Projects\Rider\AccountsManagerApp_\accounts.json";

    private static readonly List<Account> Accounts =
        JsonSerializer.Deserialize<List<Account>>(File.ReadAllText(FilePath))!;

    public static void Add(Account account)
    {
        Accounts.Add(account);
        File.WriteAllText(FilePath, JsonSerializer.Serialize(
            Accounts,
            new JsonSerializerOptions { WriteIndented = true })
        );
    }

    public static Account? Get(string email)
    {
        return Accounts.Find(a => a.Email == email);
    }

    public static bool UpdatePassword(string email, string newPassword)
    {
        var newAccount = new Account(email, newPassword);

        if (!Delete(email)) return false;

        Add(newAccount);

        return true;
    }

    public static bool Delete(string email)
    {
        var foundAccount = Get(email);

        if (foundAccount == null) return false;

        Accounts.Remove(foundAccount);

        return true;
    }
}