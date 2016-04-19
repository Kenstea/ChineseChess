using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ChineseChess.ChessItems;

namespace ChineseChess
{
    public class EngineClient
    {
        public DataReceivedEventHandler ReceviedEngineData;

        public static EngineClient DefaultEngineClient
        {
            get
            {
                if (_defaultEngineClient ==null)
                {
                    _defaultEngineClient = new EngineClient();
                }
        
               return _defaultEngineClient;
            }
          
        }
        private static EngineClient _defaultEngineClient;
        private Process _ponderEngine =null;
        private string _enginePath;
        private EngineClient(string enginePath = "")
        {
            
            if (!string.IsNullOrEmpty(enginePath))
            {
                _loadEngine(enginePath);
            } 
            else
            {
                string defaultPath = System.Environment.CurrentDirectory + "\\PonderEngine.exe";
                _loadEngine(defaultPath);
            }
            

        }

        private bool _loadEngine(string enginePath)
        {
            bool bResult = true;
            _ponderEngine = new Process();
            _ponderEngine.StartInfo.FileName = enginePath;
            _ponderEngine.StartInfo.CreateNoWindow = true;
            _ponderEngine.StartInfo.UseShellExecute = false;
            _ponderEngine.StartInfo.RedirectStandardInput = true;
            _ponderEngine.StartInfo.RedirectStandardOutput = true;
            if (_ponderEngine.Start() == true)
            {
                _ponderEngine.StandardInput.AutoFlush = true;
                _ponderEngine.OutputDataReceived +=new DataReceivedEventHandler(_ponderEngine_OutputDataReceived);
                _ponderEngine.Exited += new EventHandler(_ponderEngine_Exited);
                _ponderEngine.EnableRaisingEvents = true;
                _ponderEngine.BeginOutputReadLine();
            }
            else
            {
                throw new Exception("初始化引擎失败：" + enginePath);
               
            }
            return bResult;
        }

        public void DisposeEngine()
        {
            //_ponderEngine.Close();
            //_ponderEngine.Dispose();
            _ponderEngine.Kill();
            _ponderEngine.Dispose();
        }
        public bool changeEngine(string sPath)
        {
            _loadEngine(sPath);
            return true;
        }

        public void SendUcciCommand()
        {
            SendCommand("ucci");
        }
        
        public void SendPositionCommand(System.Windows.Forms.Panel theBoard)
        {
            
            foreach (System.Windows.Forms.Control curItem in theBoard.Controls)
            {
                if (curItem is BaseChess)
                {
                    BaseChess ci = (BaseChess)curItem;
                    Type theType = ci.GetType();
                }
            }
            string sCommand = "position ";
            SendCommand(sCommand);
        }
        
        public void SendCommand(string sCommand)
        {
            _ponderEngine.StandardInput.WriteLine(sCommand);
        }

        private void _ponderEngine_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            ReceviedEngineData(this, e);
        }
       
        private void ExecutePositionCommand(/*UcciCommand cmd*/)
        {

        }
        private void _ponderEngine_Exited(object sender, EventArgs e)
        {
           
        }
    }
}
