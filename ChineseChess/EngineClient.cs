using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ChineseChess.ChessItems;
using BussinessObjects;
using BusinessObjects.Ponder;

namespace ChineseChess
{
    public class EngineClient
    {
        public DataReceivedEventHandler ReceviedEngineData;
        public EventHandler EngineIsOK;
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
        private LogHandler m_LogHandler;
        private StringBuilder m_engineInfos;
        private EngineClient(string enginePath = "")
        {
            string sPath = System.Environment.CurrentDirectory;
            string name = "EngineClientLog";
            m_LogHandler = new LogHandler(sPath, name);
            m_engineInfos = new StringBuilder();
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
            m_LogHandler.logging("Quit");
            SendCommand("quit");
            //_ponderEngine.Kill();
            //_ponderEngine.Dispose();
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
        public void SendStartPostion()
        {
            string sFen = "startpos";
            SendPositionCommand(sFen);
        }
        public void SendPositionCommand(string sFen)
        {
            string sCommand = "position fen " + sFen;
            SendCommand(sCommand);
        }
        
        public void SendCommand(string sCommand)
        {
            m_LogHandler.logging("GUI send Command: " + sCommand);
            _ponderEngine.StandardInput.WriteLine(sCommand);
        }

        private void _ponderEngine_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            string m_UcciInfo = e.Data;
            if (!string.IsNullOrEmpty(m_UcciInfo))
            {
                m_LogHandler.logging(e.Data);
                m_engineInfos.Append(m_UcciInfo + "\n");
                if (m_UcciInfo.Contains("ucciok"))
                {
                    EngineIsOK(this, null);
                }
            }
          
            //ReceviedEngineData(this, e);
            
             
        }

        public string EngineInfo
        {
            get
            {
                return m_engineInfos.ToString();
            }
        }
        public void log(string text)
        {
            m_LogHandler.logging(text);
        }
        private void ExecutePositionCommand(/*UcciCommand cmd*/)
        {

        }
        private void _ponderEngine_Exited(object sender, EventArgs e)
        {
           
        }
    }
}
