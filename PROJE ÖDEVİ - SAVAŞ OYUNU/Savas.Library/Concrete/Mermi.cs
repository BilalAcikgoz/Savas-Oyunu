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
using System.Drawing;
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Mermi : Cisim
    {
        public Mermi(Size hareketAlaniBoyutlari, int namluOrtasiX) : base(hareketAlaniBoyutlari)
        {
            Image = Image.FromFile("Gorseller\\Mermi.png");
            BaslangicKonumunuAyarla(namluOrtasiX);
            HareketMesafesi = (int)(Height * 1.5);
        }

        private void BaslangicKonumunuAyarla(int namluOrtasiX)
        {
            Bottom = HareketAlaniBoyutlari.Height;
            Center = namluOrtasiX;
        }
    }
}
