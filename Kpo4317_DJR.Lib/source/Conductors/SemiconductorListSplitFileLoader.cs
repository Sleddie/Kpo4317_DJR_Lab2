using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4317_DJR.Lib
{
    public class SemiconductorListSplitFileLoader : ISemiconductorListLoader
    {
        private List<SemiConductor> _semiconductorList = null;
        private LoadStatus _status = LoadStatus.None;
        private readonly string _filePath = "";

        public SemiconductorListSplitFileLoader()
        {
            _filePath = AppGlobalSettings.DataFileName;
            _semiconductorList = new List<SemiConductor>();
        }

        public SemiconductorListSplitFileLoader(string filePath)
        {
            _filePath = filePath;
            _semiconductorList = new List<SemiConductor>();
        }

        public List<SemiConductor> semiconductorList { get { return _semiconductorList; } }

        public LoadStatus status { get { return _status; } }

        public void Execute()
        {
            try
            {
                _status = LoadStatus.None;
                if (_filePath == "")
                {
                    _status = LoadStatus.FileNameIsEmpty;
                    throw new Exception("Неправильные входные параметры");
                }

                if (!File.Exists(_filePath))
                {
                    _status = LoadStatus.FileNotExists;
                    throw new Exception("Файл не существует");
                }

                StreamReader sr = null;
                using (sr = new StreamReader(_filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        try
                        {
                            string[] arr = str.Split('|');
                            SemiConductor semiconductor = new SemiConductor
                            {
                                Substance_name =  arr[0],
                                ForbiddenZone_width = float.Parse(arr[1]),
                                Electron_move = int.Parse(arr[2]),
                                Hole_move = int.Parse(arr[3])
                            };
                            _semiconductorList.Add(semiconductor);
                        }
                        catch (Exception ex)
                        {
                            _status = LoadStatus.GeneralError;
                            LogUtility.ErrorLog(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtility.ErrorLog(ex);
            }
            _status = LoadStatus.Success;
        }
    }

    public enum LoadStatus
    {
        None = 0,
        Success = 1,
        FileNameIsEmpty = -1,
        FileNotExists = -2,
        GeneralError = -100
    }
}
