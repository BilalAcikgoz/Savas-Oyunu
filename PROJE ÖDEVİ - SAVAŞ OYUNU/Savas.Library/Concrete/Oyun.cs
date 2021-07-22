/****************************************************************************
**                      SAKARYA ÜNİVERSİTESİ
**            BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**              BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                NESNEYE DAYALI PROGRAMLAMA DERSİ
**                     2020-2021 BAHAR DÖNEMİ
**                       DÖNEM PROJE ÖDEVİ
**
** ÖĞRENCİ ADI............: BİLAL AÇIKGÖZ
** ÖĞRENCİ NUMARASI.......: b201200022
** DERSİN ALINDIĞI GRUP...: 1. ÖĞRETİM A GRUBU
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Savas.Library.Enum;
using Savas.Library.Interface;

namespace Savas.Library.Concrete
{
    public class Oyun : IOyun 
    {
        #region Fields

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _ucakOlusturmaTimer = new Timer { Interval = 2000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;
        private readonly Panel _savasAlaniPanel;
        private Ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();
        private static int _puan = new int();
        private int puan = new int();

        #endregion

        #region Events

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Properties

        public bool DevamEdiyorMu { get; private set; }
        public TimeSpan GecenSure 
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;
                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Metotlar

        public Oyun(Panel ucaksavarPanel, Panel savasAlaniPanel)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _savasAlaniPanel = savasAlaniPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakOlusturmaTimer.Tick += UcakOlusturmaTimer_Tick;
            _puan = puan;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
            UcaklariHareketEttir();
            VurulanUcaklariCikar();

            if (puan >= 50 && puan < 100)
                _hareketTimer.Interval = 70;
            if (puan >= 100 && puan < 150)
                _hareketTimer.Interval = 40;
            if (puan >= 150 && puan < 200)
                _hareketTimer.Interval = 20;
            if (puan >= 200)
                _hareketTimer.Interval = 10;
        }

        private void UcakOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            UcakOlustur();
        }
        
        private void UcakSavarOlustur()
        {
            _ucaksavar = new Ucaksavar(_ucaksavarPanel.Width, _ucaksavarPanel.Size);

            _ucaksavarPanel.Controls.Add(_ucaksavar);
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            if (DevamEdiyorMu == false)
                return;

            _ucaksavar.HareketEttir(yon);
        }

        private void MermileriHareketEttir()
        {
            for (int i = _mermiler.Count - 1; i >= 0; i--)
            {
                var mermi = _mermiler[i];
                var siniraUlastiMi = mermi.HareketEttir(Yon.Yukari);

                if (siniraUlastiMi == true)
                {
                    _mermiler.Remove(mermi);
                    _savasAlaniPanel.Controls.Remove(mermi);
                }
            }
        }

        private void UcakOlustur()
        {
            var ucak = new Ucak(_savasAlaniPanel.Size);
            _savasAlaniPanel.Controls.Add(ucak);
            _ucaklar.Add(ucak);
        }

        private void UcaklariHareketEttir()
        {
            foreach (var ucak in _ucaklar)
            {
                var carptiMi = ucak.HareketEttir(Yon.Asagi);
                if (carptiMi == false)
                    continue;

                Bitir();
                break;
            }
        }

        private void VurulanUcaklariCikar()
        {
            for (int i = _ucaklar.Count - 1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];
                var vuranMermi = ucak.VurulduMu(_mermiler);
                var vurulanUcakSayisi = vuranMermi;

                if (vuranMermi is null)
                    continue;
                _ucaklar.Remove(ucak);
                _mermiler.Remove(vuranMermi);
                _savasAlaniPanel.Controls.Remove(ucak);
                _savasAlaniPanel.Controls.Remove(vuranMermi);
                puan += 5;
            }

        }

        private void ZamanlayicilariBaslat()
        {
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _ucakOlusturmaTimer.Start();
        }

        private void ZamanlayicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _ucakOlusturmaTimer.Stop();
        }

        public void Baslat()
        {
            if (DevamEdiyorMu == true)
                return;
            else
                DevamEdiyorMu = true;
            ZamanlayicilariBaslat();

            UcakSavarOlustur();
            UcakOlustur();
        }
    
        public void Bitir()
        {
            if (DevamEdiyorMu == false)
                return;
            else
                DevamEdiyorMu = false;

            ZamanlayicilariDurdur();
            MessageBox.Show("Puanınız: " + puan);
        } 

        public void AtesEt()
        {
            if (DevamEdiyorMu == false)
                return;

            var mermi = new Mermi(_savasAlaniPanel.Size, _ucaksavar.Center);
            _mermiler.Add(mermi);
            _savasAlaniPanel.Controls.Add(mermi);
        }

        public void OyunuDurdur()
        {
            if (DevamEdiyorMu == false)
                return;
            else
                DevamEdiyorMu = false;

            ZamanlayicilariDurdur();
        }

        public void OyunuDevamEttir()
        {
            if (DevamEdiyorMu == true)
                return;
            else
                DevamEdiyorMu = true;
            ZamanlayicilariBaslat();
        }

        #endregion

    }
}
