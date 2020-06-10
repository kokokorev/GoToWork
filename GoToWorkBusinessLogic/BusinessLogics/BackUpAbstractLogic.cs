using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public abstract class BackUpAbstractLogic
    {
        public void CreateProviderArchive(BackupBindingModel model)
        {
            CreateArchive(model.SelectedPath, "ProviderSaveToFile");

        }

        private void CreateArchive(string folderName, string methodName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderName);
                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }

                string fileName = $"{folderName}.zip";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // берем сборку, чтобы от нее создавать объекты
                Assembly assem = GetAssembly();
                // вытаскиваем список классов для сохранения
                var dbsets = GetFullList();
                // берем метод для сохранения (из базвого абстрактного класса)
                MethodInfo method =
                    GetType().BaseType.GetTypeInfo().GetDeclaredMethod(methodName);
                foreach (var set in dbsets)
                {
                    // создаем объект из класса для сохранения
                    var elem =
                        assem.CreateInstance(set.PropertyType.GenericTypeArguments[0].FullName);
                    // генерируем метод, исходя из класса
                    MethodInfo generic = method.MakeGenericMethod(elem.GetType());
                    // вызываем метод на выполнение
                    generic.Invoke(this, new object[] { folderName });
                }

                // архивируем
                ZipFile.CreateFromDirectory(folderName, fileName);
                // удаляем папку
                dirInfo.Delete(true);
            }
            catch (Exception)
            {
                // делаем проброс
                throw;
            }
        }

        private void ProviderSaveToFile<T>(string folderName) where T : class, new()
        {
            var records = GetList<T>();

            T obj = new T();
            var tmp = obj.GetType().Name;
            if (!obj.GetType().Name.Equals("Toy") && !obj.GetType().Name.Equals("ToyParts"))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
                using (FileStream fs = new FileStream(string.Format("{0}/{1}.json", folderName, obj.GetType().Name),
                    FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, records);
                }
            }
        }

        protected abstract Assembly GetAssembly();
        protected abstract List<PropertyInfo> GetFullList();
        protected abstract List<T> GetList<T>() where T : class, new();
    }
}