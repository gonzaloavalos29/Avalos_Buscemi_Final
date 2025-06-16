using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

public static class ServicioDeHash
{
    public static string HashSHA256(string contraseña)
    {
        using var sha = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}