using MySql.Data.MySqlClient;
using SGHE.Client;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class UsuarioDao
    {
        public String RegistrarUsuario(Usuario usuario)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    string sql = "INSERT INTO usuario(nombre,apellidoPaterno,apellidoMaterno,fechaNacimiento,telefono,email,domicilio,password,idTipoUsuario) VALUES (@nombre,@apellidoPaterno,@apellidoMaterno,@fechaNacimiento,@telefono,@email,@domicilio,@password,@idTipoUsuario)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@apellidoPaterno", usuario.ApellidoPaterno);
                    mySqlCommand.Parameters.AddWithValue("@apellidoMaterno", usuario.ApellidoMaterno);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", usuario.FechaNacimiento);
                    mySqlCommand.Parameters.AddWithValue("@telefono", usuario.Telefono);
                    mySqlCommand.Parameters.AddWithValue("@email", usuario.Email);
                    mySqlCommand.Parameters.AddWithValue("@domicilio", usuario.Domicilio);
                    mySqlCommand.Parameters.AddWithValue("@password", usuario.Password);
                    mySqlCommand.Parameters.AddWithValue("@idTipoUsuario", usuario.IdTipoUusario);
                    mySqlCommand.Prepare();
                    if (mySqlCommand.ExecuteNonQuery() > 0)
                    {
                        mensaje = "El usuario se ha con éxito";
                    }
                    else
                    {
                        mensaje = "El usuario no ha podido registrarse";
                    }

                }
                catch (Exception e)
                {
                    mensaje = "El usuario no ha podido registrarse";
                }
            }

            return mensaje;
        }

        public string RegistrarDocente(int idUsuario,string numDocente)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    string sql = "INSERT INTO docente(idUsuario,numDocente) VALUES (@idUsuario,@numDocente)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    mySqlCommand.Parameters.AddWithValue("@numDocente",numDocente);
                    mySqlCommand.Prepare();
                    if (mySqlCommand.ExecuteNonQuery() > 0)
                    {
                        mensaje = "Docente se ha registrado con éxito";
                    }
                    else
                    {
                        mensaje = "El docente no ha podido registrarse";
                    }

                }
                catch (Exception e)
                {
                    mensaje = "El docente no ha podido registrarse";
                }
            }

            return mensaje;
        }

        public int RecuperarIdUsuario(Docente docente)
        {
            int idUsuario=0;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM usuario WHERE nombre=@nombre";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombre", docente.Nombre);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        idUsuario = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return idUsuario;
        }
    }
}
