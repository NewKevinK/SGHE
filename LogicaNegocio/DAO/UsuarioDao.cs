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

        public int RecuperarIdAlumnoDeUsuario(int idUsuario)
        {
            int idAlumno = 0;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT alumno.idAlumno FROM usuario INNER JOIN alumno ON usuario.idUsuario = alumno.idUsuario WHERE usuario.idUsuario = @idUsuario";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        idAlumno = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return idAlumno;
        }

        public Persona Autenticacion(string password, string email)
        {
            Persona personaAuth = new Persona();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            //MessageBox.Show(password + email);
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT idUsuario, idTipoUsuario FROM usuario WHERE email = @email AND PASSWORD =@password";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@email", email);
                    mySqlCommand.Parameters.AddWithValue("@password", password);

                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        personaAuth.idUsuario = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        personaAuth.idTipoUsuario = ((respuestaBD.IsDBNull(1)) ? 0 : respuestaBD.GetInt32(1));

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return personaAuth;
        }


        public Docente RecuperarDocentePorId(int idUsuario)
        {
            Docente docente = new Docente();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM usuario WHERE idUsuario=@idUsuario";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        docente.IdUsuario = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        docente.Nombre = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        docente.ApellidoPaterno = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        docente.ApellidoMaterno = ((respuestaBD.IsDBNull(3)) ? "" : respuestaBD.GetString(3));
                        docente.FechaNacimiento = DateTime.Parse((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        docente.Domicilio = ((respuestaBD.IsDBNull(5)) ? "" : respuestaBD.GetString(5));
                        docente.Telefono = ((respuestaBD.IsDBNull(6)) ? "" : respuestaBD.GetString(6));
                        docente.Email = ((respuestaBD.IsDBNull(7)) ? "" : respuestaBD.GetString(7));
                        string password = ((respuestaBD.IsDBNull(8)) ? "" : respuestaBD.GetString(8));
                        docente.IdTipoUusario = ((respuestaBD.IsDBNull(9)) ? 0 : respuestaBD.GetInt32(9));

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return docente;
        }

        public Alumno RecuperarAlumnoPorId(int idUsuario)
        {
            Alumno alumno = new Alumno();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM usuario WHERE idUsuario=@idUsuario";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        alumno.IdUsuario = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        alumno.Nombre = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        alumno.ApellidoPaterno = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        alumno.ApellidoMaterno = ((respuestaBD.IsDBNull(3)) ? "" : respuestaBD.GetString(3));
                        alumno.FechaNacimiento = DateTime.Parse((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        alumno.Domicilio = ((respuestaBD.IsDBNull(5)) ? "" : respuestaBD.GetString(5));
                        alumno.Telefono = ((respuestaBD.IsDBNull(6)) ? "" : respuestaBD.GetString(6));
                        alumno.Email = ((respuestaBD.IsDBNull(7)) ? "" : respuestaBD.GetString(7));
                        string password = ((respuestaBD.IsDBNull(8)) ? "" : respuestaBD.GetString(8));
                        alumno.IdTipoUusario = ((respuestaBD.IsDBNull(9)) ? 0 : respuestaBD.GetInt32(9));

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return alumno;
        }
        public Persona RecuperarAdministradorPorId(int idUsuario)
        {
            Persona usuario = new Persona();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM usuario WHERE idUsuario=@idUsuario";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        usuario.idPersona = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        usuario.nombre = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        usuario.ApellidoPaterno = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        usuario.ApellidoMaterno = ((respuestaBD.IsDBNull(3)) ? "" : respuestaBD.GetString(3));
                        usuario.FechaNacimiento = DateTime.Parse((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        usuario.Domicilio = ((respuestaBD.IsDBNull(5)) ? "" : respuestaBD.GetString(5));
                        usuario.Telefono = ((respuestaBD.IsDBNull(6)) ? "" : respuestaBD.GetString(6));
                        usuario.Email = ((respuestaBD.IsDBNull(7)) ? "" : respuestaBD.GetString(7));
                        string password = ((respuestaBD.IsDBNull(8)) ? "" : respuestaBD.GetString(8));
                        usuario.IdTipoUusario = ((respuestaBD.IsDBNull(9)) ? 0 : respuestaBD.GetInt32(9));

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return usuario;
        }
    }
}
