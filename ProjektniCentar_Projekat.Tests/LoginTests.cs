using System;
using ProjektniCentar_Projekat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektniCentar_Projekat.Models;

namespace ProjektniCentar_Projekat.Tests
{
    public class LoginTests
    {
        [TestMethod]
        public void Authorize_PravoPristupaAdmin()
        {
            var Expected = new Korisnik();

            var Actual = Expected.PravoPristupa == "admin";

            Assert.Equals(Expected, Actual);
        }

        [TestMethod]
        public void Authorize_PravoPristupaKorisnik()
        {
            var Expected = new Korisnik();

            var Actual = Expected.PravoPristupa == "korisnik";

            Assert.Equals(Expected, Actual);
        }

        [TestMethod]
        public void Authorize_PravoPristupaPregledac()
        {
            Korisnik Expected = new Korisnik();

            var Actual = Expected.PravoPristupa == "pregledac";

            Assert.Equals(Expected, Actual);
        }
    }
}
