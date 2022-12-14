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

        

        public Persona Autenticacion(string password, string email)
        {
            Persona personaAuth = new Persona();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT idUsuario, idTipoUsuario FROM usuario WHERE email = '@email' AND PASSWORD =@password";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@email",email);
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

        public Usuario ObtenerUsuario(Persona personaAuth)
        {
            Persona persona = new Persona();
            int id = personaAuth.idUsuario;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string sql;
            if (conexionBD != null)
            {
                try
                {
                    if(id == 1)
                    {



                    }else if ((id == 2) || (id == 3) )
                    {



                    }
                    else
                    {
                        string sqll = "SELECT usuario.idUsuario, tipousuario, idAlumno FROM usuario" +
                        " LEFT JOIN alumno ON usuario.idUsuario = alumno.idUsuario " +
                        "LEFT JOIN tipousuario ON usuario.idTipoUsuario = tipousuario.idTipoUsuario WHERE usuario.idUsuario = @id";
                        MySqlCommand mySqlCommandd = new MySqlCommand(sqll, conexionBD);
                        mySqlCommandd.Parameters.AddWithValue("@id", id);
                        MySqlDataReader respuestaBDD = mySqlCommandd.ExecuteReader();
                        while (respuestaBDD.Read())
                        {
                            persona.idUsuario = ((respuestaBDD.IsDBNull(0)) ? 0 : respuestaBDD.GetInt32(0));
                            persona.tipoUsuario = ((respuestaBDD.IsDBNull(1)) ? "" : respuestaBDD.GetString(1));
                            persona.idPersona = ((respuestaBDD.IsDBNull(2)) ? 0 : respuestaBDD.GetInt32(2));
                        }


                    }
                   /* string sql = "SELECT usuario.idUsuario, tipousuario, idAlumno FROM usuario" +
                        " LEFT JOIN alumno ON usuario.idUsuario = alumno.idUsuario " +
                        "LEFT JOIN tipousuario ON usuario.idTipoUsuario = tipousuario.idTipoUsuario WHERE usuario.idUsuario = @id" ;
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@id",id);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        persona.idUsuario = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        persona.tipoUsuario = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        persona.idPersona = ((respuestaBD.IsDBNull(2)) ? 0 : respuestaBD.GetInt32(2));
                        

                    } */
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
