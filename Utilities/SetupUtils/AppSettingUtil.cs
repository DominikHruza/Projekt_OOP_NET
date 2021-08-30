
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities.OptionUtils;

namespace Utilities.SetupUtils
{
    public class AppSettingUtil
    {
        public static string GetSettingFromSetupFile(string filePath)
        {
            try
            {

                string[] settings = File.ReadAllLines(filePath);
                return settings[0];
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(IndexOutOfRangeException))
                {
                    return "";
                }

                throw ex;
            }
        }

        public static string[] GetLinesFromSetupFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveOptionToSetupFile(string option, string filePath)
        {

            try
            {
                string fullPath = GetBaseSaveDirPath() + @"\" + filePath;
                File.WriteAllText(fullPath, option);
                File.WriteAllText(filePath, option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveOptionToSetupFile(string[] option, string filePath)
        {
            try
            {
                string fullPath = GetBaseSaveDirPath() + @"\" + filePath;
                File.WriteAllLines(fullPath, option);
                File.WriteAllLines(filePath, option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ContestType? GetContestConfig()
        {
            
            string contestSetting = GetSettingFromSetupFile(
               AppConstants.CONTEST_SETTINGS_PATH);

            foreach (string name in Enum.GetNames(typeof(ContestType)))
            {
                if (name == contestSetting)
                {
                    return (ContestType)Enum.Parse(typeof(ContestType), name);
                }
            }

            return null;
        }

        public static string GetBaseSaveDirPath()
        {
            return Directory.GetParent(
                Directory.GetCurrentDirectory())
                .Parent.Parent.FullName + @"\Utilities";
        }

        public static void SetGlobalization()
        {
            try
            {
                string lang = GetLinesFromSetupFile(AppConstants.LANGUAGE_SETTINGS_PATH)[0];
                if (lang == null)
                {
                    lang = "EN";
                }
                CultureInfo culture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception)
            {

               
            } 
            
            
        }
    }
}
