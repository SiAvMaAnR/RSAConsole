using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			RSA algorithmRSA = new RSA(17,36563,57731);//Генерируем ключи

			algorithmRSA.getPublicKey(out long e, out long n1);//Возврат открытых ключей

			string[] rsaEncrypt = algorithmRSA.Encrypt("PUBLIC", e, n1);//Зашифровываем сообщение

			algorithmRSA.getPrivateKey(out long d, out long n2);//Возврат открытых ключей

			string rsaDecrypt = algorithmRSA.Decrypt(rsaEncrypt, d, n2);//Дешифровываем сообщение


			algorithmRSA.CipherLog();
		}
	}
}
