using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public static class CryptoUtility
{
    private static readonly string _encryptionKey = "2001062620010626"; 
    // ��ȣȭ �� ����� IV(�ʱ�ȭ ����)�� ������ IV�� ��ȣȭ �� ����ؾ� �����Ϳ� ���� �����ϴ�.

    public static string Encrypt(string text)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_encryptionKey);
            aes.IV = new byte[16]; // IV�� 0���� �ʱ�ȭ�Ͽ� ���
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] textBytes = Encoding.UTF8.GetBytes(text);

            byte[] encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
            return Convert.ToBase64String(encryptedBytes);
        }
    }

    public static string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_encryptionKey);
            aes.IV = new byte[16]; // IV�� ��ȣȭ�� ���� �����ϰ� ����
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
