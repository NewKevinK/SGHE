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

        public string RegistrarDocente(Docente docente)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    string sql = "INSERT INTO docente(idUsuario,numDocente) VALUES (@idUsuario,@numDocente)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", docente.IdUsuario);
                    mySqlCommand.Parameters.AddWithValue("@numDocente",docente.NumDocente);
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

        public string RegistrarAlumno(Alumno alumno)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    string sql = "INSERT INTO alumno(idUsuario,matricula,idCarrera) VALUES (@idUsuario,@matricula,@idCarrera)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", alumno.IdUsuario);
                    mySqlCommand.Parameters.AddWithValue("@matricula", alumno.Matricula);
                    mySqlCommand.Parameters.AddWithValue("@idCarrera", alumno.IdCarrera);
                    mySqlCommand.Prepare();
                    if (mySqlCommand.ExecuteNonQuery() > 0)
                    {
                        mensaje = "Alumno se ha registrado con éxito";
                    }
                    else
                    {
                        mensaje = "El Alumno no ha podido registrarse";
                    }

                }
                catch (Exception e)
                {
                    mensaje = "Ha ocurrido un error, intentelo más tarde";
                }
            }

            return mensaje;
        }

        public int RecuperarIdUsuario(Usuario usuario)
        {
            int idUsuario=0;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM usuario WHERE nombre=@nombre";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
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

        

        public int Autenticacion(string password, string email)
        {
            int idUsuario=0;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT idUsuario FROM usuario WHERE email = '@email' AND PASSWORD =@password";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@email",email);
                    mySqlCommand.Parameters.AddWithValue("@password", password);

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

        public Usuario ObtenerUsuario(int id)
        {
            Persona persona = new Persona();
           //Usuario usuario = new Usuario();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                   // mySqlCommand.Parameters.AddWithValue();
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //return aula;

            return null;
        }
    }
}
