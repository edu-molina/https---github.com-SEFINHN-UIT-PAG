using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PAG.Models
{
    /// <summary>
    /// Clase para encriptar valor en .net y descriptarlo del lado ORACLE.
    /// </summary>
    public class EncriptarNetOracle
    {
        /// <summary>
        /// Función para encriptar string
        /// </summary>
        /// <param name="pDatos">Dato a encriptar</param>
        /// <param name="pKey">Llave secreta de encriptación-desencriptacion</param>
        /// <returns>String encriptado</returns>
        public string Encriptar(string pDatos, string pKey)
        {

            string text = pDatos;

            //string key = "5379075357908764";
            string key = pKey;
            string iv = "0123456789ABCDEF";

            byte[] textBytes = new byte[text.Length];
            textBytes = ASCIIEncoding.ASCII.GetBytes(text);

            byte[] keyBytes = new byte[key.Length];
            keyBytes = ASCIIEncoding.ASCII.GetBytes(key);

            byte[] ivBytes = new byte[iv.Length];
            ivBytes = HexStringToByteArray(iv);
            byte[] encrptedBytes = Encrypt(textBytes, keyBytes, ivBytes);

            return BitConverter.ToString(encrptedBytes).Replace("-", "");

        }
        /// <summary>
        /// Convierte un string hexadecimal a un array de byte
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        //encripta el array de bytes
        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            //CREAR ALGORITMO SIMETRICO
            TripleDES alg = TripleDES.Create();
            alg.Padding = PaddingMode.ANSIX923;
            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }
    }
}