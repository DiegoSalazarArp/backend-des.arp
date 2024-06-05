using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace API_DES_BOOK.Models.Log
{
    public class Logger
    {

        public enum TipoLog
        {

            /// <summary>
            /// Indica un evento de tipo informativo
            /// </summary>
            Info = 0,

            /// <summary>
            /// Indica un evento de tipo precaucion
            /// </summary>
            Warning = 1,

            /// <summary>
            /// Indica un evento de tipo error
            /// </summary>
            Error = 2
        }


        public enum Controller
        {
            Book = 0,
        }

        //private async Task EscribeLog(string msgFormateado)
        //{

        //    try
        //    {

        //        //verificar si no existe la carpeta
        //        if (!Directory.Exists(RutaLog))
        //        {
        //            //en caso de no existir crear la carpeta
        //            Directory.CreateDirectory(RutaLog);
        //        }

        //        //crea (si no existe) y agrega un nuevo registro en el archivo txt
        //        using (StreamWriter escritor = new StreamWriter(RutaArchivo, true))
        //        {
        //            //inserta la linea
        //            await escritor.WriteLineAsync(msgFormateado);
        //            //suelta el archivo
        //            escritor.Close();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        try
        //        {

        //            using (StreamWriter escritor = new StreamWriter(RutaArchivo, true))
        //            {
        //                //inserta la linea
        //                escritor.WriteLine(msgFormateado);
        //                //suelta el archivo
        //                escritor.Close();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        throw;
        //    }

        //}


        //public int InsertaLog(TipoLog tipoRegistroLog, Exception ex, bool enviarEmail, Controller controller)
        //{
        //    string msgTipoLog = GetTipoRegistro(tipoRegistroLog);
        //    Errores errores = new Errores(ex);

        //    //realizar registro en la base de datos
        //    //Bd.MOKEntities SqlServer = new Bd.MOKEntities();

        //    //reformatear la ruta
        //    RutaArchivo = RutaLog + "\\" + "LOG_Eventos" + DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".txt";

        //    //insertar registro log error en la base de datos
        //    //var IdLog = SqlServer.SP_INSERT_LOGERRORES(errores.SitioCod, errores.Message, errores.StackTrace, errores.Source, errores.TargetSite, errores.UsuCodigo, errores.UsuId, errores.SuIdSesion).FirstOrDefault();
        //    var IdLog = -1;
        //    //eliminar espacio de memoria
        //    //SqlServer.Dispose();

        //    //formatear mensaje
        //    string msgFormateado = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + msgTipoLog + "ID_LOG: " + IdLog.ToString();
        //    //realizar registro
        //    EscribeLog(msgFormateado);
        //    //formatear mensaje
        //    msgFormateado = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + msgTipoLog + "Tipo: " + ex.GetType().ToString();
        //    //realizar registro
        //    EscribeLog(msgFormateado);
        //    //formatear mensaje
        //    msgFormateado = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + msgTipoLog + "Mensaje: " + ex.Message.ToString();
        //    //realizar registro
        //    EscribeLog(msgFormateado);
        //    //formatear mensaje
        //    msgFormateado = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + msgTipoLog + "InnerException: " + ex.InnerException;
        //    //realizar registro
        //    EscribeLog(msgFormateado);
        //    //formatear mensaje
        //    msgFormateado = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + msgTipoLog + "StackTrace: " + ex.StackTrace.ToString();
        //    //realizar registro
        //    EscribeLog(msgFormateado);
        //    //formatear mensaje
        //    msgFormateado = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + msgTipoLog + "Source: " + ex.Source.ToString();
        //    //realizar registro
        //    EscribeLog(msgFormateado);

        //    //separar errores
        //    EscribeLog("------------------------------------------------------------------------------------");

        //    if (enviarEmail)
        //    {
        //        //obtener datos desde el webconfig
        //        string Desde = ConfigurationManager.AppSettings["log_desde"];
        //        string para = ConfigurationManager.AppSettings["log_para"];
        //        string cc = ConfigurationManager.AppSettings["log_cc"];
        //        string dns = ConfigurationManager.AppSettings["log_dns"];
        //        string nomApp = ConfigurationManager.AppSettings["log_nomapp"];
        //        //generar y capturar cuerpo del correo
        //        string body = CuerpoEmail(ex, nomApp, errores.SitioCod.ToString());

        //        Mail correo = new Mail
        //        {
        //            Desde = Desde,
        //            Para = para,
        //            CC = cc,
        //            Asunto = "Error " + nomApp,
        //            Mensaje = body,
        //            IsHtmlBody = true,
        //            Prioridad = MailPriority.High,
        //            Dns = dns,
        //            AdjuntarDoc = false
        //        };

        //        //enviar email
        //        bool estadoEnvio = Mail.EnviarCorreo(correo);
        //        if (estadoEnvio)
        //        {
        //            InsertaLog(Logger.TipoLog.Info, "Email enviado exitosamente a: " + para.Replace(";", " "));
        //        }
        //        else
        //        {
        //            InsertaLog(Logger.TipoLog.Warning, "Error al notificar via Email el error");
        //        }
        //    }

        //    return Convert.ToInt32(IdLog);
        //}

    }
}