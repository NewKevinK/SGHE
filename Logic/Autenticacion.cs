using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SGHE.Logic
{
    class Autenticacion
    {
        public void Login(string email, string password)
        {
            try
            {

            }
            catch (SystemException e)
            {
                
            }
        }

        public string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }



    }

    

    
}
