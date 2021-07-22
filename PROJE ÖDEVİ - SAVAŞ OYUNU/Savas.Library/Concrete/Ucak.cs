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
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Ucak : Cisim
    {
        private static readonly Random Random = new Random();
        private static int puan = new int();

        public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Image = Image.FromFile("Gorseller\\Ucak.png");
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
            HareketMesafesi = (int)(Height * 0.1);
        }

        public Mermi VurulduMu(List<Mermi> mermiler)
        {
            puan = 0;
            foreach (var mermi in mermiler)
            {
                var vurulduMu = mermi.Top < Bottom && mermi.Right > Left && mermi.Left < Right;

                if (vurulduMu == true)
                    return mermi;
            }

            return null;
        }
    }
}
