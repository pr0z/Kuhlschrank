using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Business.CamCapturer
{
    public class CamCapturer : IDisposable
    {
        private Bitmap _currentBitmap;

        private VideoCaptureDevice _source;
        public VideoCaptureDevice Source
        {
            get
            {
                if (_source == null)
                {
                    int index = 0;
                    FilterInfoCollection col = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("indexCam"))
                    {
                        int.TryParse(ConfigurationManager.AppSettings["indexCam"], out index);
                        index = index < col.Count ? index : col.Count - 1;
                    }
                    _source = new VideoCaptureDevice(col[index].MonikerString);
                    _source.DesiredFrameSize = _source.VideoCapabilities[_source.VideoCapabilities.ToList().Count - 1].FrameSize;
                    _source.DesiredFrameRate = 10;
                    _source.SnapshotFrame += _source_SnapshotFrame;
                    _source.NewFrame += _source_NewFrame;
                    _source.ProvideSnapshots = true;
                }
                return _source;
            }
        }

        void _source_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            _currentBitmap = eventArgs.Frame.Clone() as Bitmap;
        }

        void _source_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            _currentBitmap = eventArgs.Frame.Clone() as Bitmap;
        }

        public void Start()
        {
            if (Source != null && !Source.IsRunning)
            {
                _source.Start();
            }
        }

        public Bitmap GetCapture()
        {
            Start();
            int nb = 0;
            while (_currentBitmap == null && nb < 100)
            {
                Thread.Sleep(100);
                nb++;
            }
            return _currentBitmap;
        }

        #region IDisposable Membres

        public void Dispose()
        {
            if (_source != null)
            {
                _source.Stop();
            }
            _source = null;
        }

        #endregion
    }
}
