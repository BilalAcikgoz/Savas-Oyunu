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
using Savas.Library.Enum;

namespace Savas.Library.Interface
{
    interface IOyun
    {
        event EventHandler GecenSureDegisti;

        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }

        void Baslat();
        void AtesEt();
        void UcaksavariHareketEttir(Yon yon);
        void OyunuDurdur();
        void OyunuDevamEttir();
    }
}
