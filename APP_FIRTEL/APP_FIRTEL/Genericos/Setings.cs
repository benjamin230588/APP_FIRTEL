using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Genericos
{
    public class Setings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        //idusuario

        private const string SettingsKeyIdUsuario = "idusuario";
        private static readonly int SettingsDefaultIdUsuario = 0;
        //idtipousuario
        private const string SettingsKeyIdTipoUsuario = "idtipousuario";
        private static readonly int SettingsDefaultIdTipoUsuario = 0;
        //recordar
        private const string SettingsKeyRecordarContra = "recordarcontra";
        private static readonly bool SettingsDefaultRecordarContra = false;
        
        #endregion

        //idusuario
        public static int IdUsuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyIdUsuario, SettingsDefaultIdUsuario);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyIdUsuario, value);
            }
        }
        //idtipousuario
        public static int IdTipoUsuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyIdTipoUsuario, SettingsDefaultIdTipoUsuario);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyIdTipoUsuario, value);
            }
        }

        public static bool RecordarContra
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyRecordarContra, SettingsDefaultRecordarContra);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyRecordarContra, value);
            }
        }

        
    }
}
