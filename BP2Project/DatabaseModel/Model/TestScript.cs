using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Model
{
    public class TestScript
    {
        public TestScript() {}

        public void GenerateProgramer()
        {
            using (var db = new ProjectModelContainer())
            {
                Programer newProgramer = new Programer
                {
                    Id = "Prog1",
                    D_ZAP = DateTime.Now,
                    O_PROD = 13,
                    PLAT = 10000
                };

                PoslovniProstor poslovniProstor = new PoslovniProstor
                {
                    SP = "Prostor1",
                    DIM = 80.0M,
                    BRM = 10
                };

                newProgramer.PoslovniProstor = poslovniProstor;

                Tim tim = new Tim();
                tim.ST = "Tim1";
                tim.PR = "Research&Development";
                tim.VodjaTima = newProgramer;

                newProgramer.ClanTima = tim;
                newProgramer.VodiTim = tim;


                db.PoslovniProstori.Add(poslovniProstor);
                db.Zaposleni.Add(newProgramer);
                db.Timovi.Add(tim);

                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }
    }
}
