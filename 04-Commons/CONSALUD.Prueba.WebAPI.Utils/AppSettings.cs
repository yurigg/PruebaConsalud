using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.Utils
{
    /// <summary>
    /// Singleton de configuraciones de la aplicación
    /// </summary>
    public class AppSettings
    {
        private static AppSettings _singletonInstance;
        public static void Init(AppSettings appSettings)
        {
            _singletonInstance = appSettings;
        }
        public static AppSettings GetInstance() => _singletonInstance;



        /// <summary>
        /// Tiempo de espera antes de abortar el intento de ejecutar un SqlCommand y lanzar un error.
        /// </summary>
        public int SqlCommandTimeout { get; set; }

        /// <summary>
        /// Zona horaria que debe usar esta la aplicación para obtener instancias de DateTime actual.
        /// </summary>
        public string TimeZoneSolution { get; set; }

        /// <summary>
        /// Tamaño maximo permitido de una petición en bytes
        /// </summary>
        public int MaxRequestSize { get; set; }

        /// <summary>
        /// Secret key para validación de token
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Configuración para establecer cabeceras de seguridad
        /// </summary>
        public SecurityHeaders SecurityHeaders { get; set; }

    }



    /// <summary>
    /// Configuración para establecer cabeceras de seguridad
    /// </summary>
    public class SecurityHeaders
    {
        public string PermissionsPolicy { get; set; }
        public int MaxDaysHsts { get; set; }
    }


}

