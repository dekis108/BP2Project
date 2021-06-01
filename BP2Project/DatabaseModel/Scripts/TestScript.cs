using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Model
{
    public class TestScript
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());

        public TestScript() {}

        public void Run()
        {
            using (var db = new ProjectModelContainer())
            {
                //generate 10 of each
                for (int i = 0; i < 10; ++i)
                {
                    GeneratePoslovniProstor(db, "PP" + i);
                    GenerateTim(db, "T" + i);
                    GenerateProgramer(db, "PR" + i);
                    GenerateAdmin(db, "A" + i);
                    GenerateDispecer(db, "D" + i);
                    GenerateMenadzer(db, "M" + i);
                    GenerateRacunar(db, "RAC" + i);
                    GenerateMobilni(db, "MOB" + i);
                    GenerateProjekat(db, "P" + i, i);
                }

                //assign all programers to random teams
                for (int i = 0; i < 10; ++i)
                {
                    AssignProgramerToTeam(db, "PR" + i, "T" + rand.Next(0,10));
                }


                db.SaveChanges(); //have to save now for other code to work

                //assign a team lead to every team that has atleast 1 member
                AssignTeamLeads(db);

                //assign work room to every team member
                AssignRooms(db);

                //Assign a dispatcher to every mobile device
                AssignDispecer(db);

                //assign pc's to workrooms
                AssignPCRoom(db);

                //arrange team 1->2->3
                AssignTimHiearchy(db);

                //assign projects to teams
                AssignProjekatToTims(db);

                //Assign Menadzer to look over a team working on a project
                //first five overlook three each
                AssignMenadzer(db);

                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        private void AssignMenadzer(ProjectModelContainer db)
        {
            var listMenadzer = db.Zaposleni.Where(x => x is Menadzer).ToList();
            var listGerund = db.TimRadiNaProjektu.ToList();

            for (int i = 0; i < 5; ++i)
            {
                ((Menadzer)listMenadzer[i]).TimRadiNaProjektus.Add(listGerund[i]);
                ((Menadzer)listMenadzer[i]).TimRadiNaProjektus.Add(listGerund[(i + 1)%10]);
                ((Menadzer)listMenadzer[i]).TimRadiNaProjektus.Add(listGerund[(i + 2) % 10]);
            }
        }

        private void AssignProjekatToTims(ProjectModelContainer db)
        {
            var listTimova = db.Timovi.ToList();
            var listGerund = db.TimRadiNaProjektu.ToList();

            for(int i = 0; i < 10; ++i)
            {
                listTimova[i].TimRadiNaProjektu.Add(listGerund[i]); 
            }
        }

        private TimRadiNaProjektu GenerateTimRadinaProjektu(ProjectModelContainer db, string v)
        {
            TimRadiNaProjektu newTRNP = new TimRadiNaProjektu
            {
                Id = v,
                OZ = 0M,
            };
            db.TimRadiNaProjektu.Add(newTRNP);
            return newTRNP;
        }

        private void GenerateProjekat(ProjectModelContainer db, string v, int i)
        {
            Projekat newP = new Projekat
            {
                SP = v,
                DD = DateTime.Now,
                DP = DateTime.Now,
                RI = DateTime.Now.AddDays(7),
                KI = 7,
                SZ = "Losa specifikacija",
            };
            
            TimRadiNaProjektu proj = GenerateTimRadinaProjektu(db, "TRNP" + i);
            newP.TimRadiNaProjektus = proj;
            db.Projekti.Add(newP);
        }

        private void AssignTimHiearchy(ProjectModelContainer db)
        {
            Tim tim1 = db.Timovi.Find("T1");
            Tim tim2 = db.Timovi.Find("T2");
            Tim tim3 = db.Timovi.Find("T3");

            tim3.Nadredjeni = tim2;
            tim2.Nadredjeni = tim1;
        }

        private void AssignPCRoom(ProjectModelContainer db)
        {
            foreach (Racunar pc in db.Hardveri.Where(x => x is Racunar))
            {
                int rndInt = rand.Next(0, 10);
                var rnd = db.PoslovniProstori.Where(x => x.SP == "PP" + rndInt).ToList();
                pc.PoslovniProstor = (PoslovniProstor)rnd.First();
            }
        }

        private void AssignDispecer(ProjectModelContainer db)
        {
            foreach(Mobilni mobile in db.Hardveri.Where(x => x is Mobilni))
            {
                int rndInt = rand.Next(0, 10);
                var rnd = db.Zaposleni.Where(x => x.Id == "D" + rndInt).ToList();
                mobile.Dispecer = (Dispecer)rnd.First();
            }
        }

        private void GenerateMobilni(ProjectModelContainer db, string v)
        {
            Mobilni newM = new Mobilni
            {
                SH = v,
                CPU = "CPU2",
                HDD = 64,
                RAM = 8,
                MDIM = 21.47M,
                OS = "OS1"
            };

            db.Hardveri.Add(newM);
        }

        private void GenerateRacunar(ProjectModelContainer db, string v)
        {
            Racunar newR = new Racunar
            {
                SH = v,
                CPU = "CPU1",
                HDD = 500,
                RAM = 32,
                VM = "VM1"
            };

            db.Hardveri.Add(newR);
        }

        private void GenerateMenadzer(ProjectModelContainer db, string v)
        {
            Menadzer newM = new Menadzer
            {
                Id = v,
                D_ZAP = DateTime.Now,
                PLAT = 10000,
            };

            db.Zaposleni.Add(newM);
        }

        private void GenerateDispecer(ProjectModelContainer db, string v)
        {
            Dispecer newD = new Dispecer
            {
                Id = v,
                D_ZAP = DateTime.Now,
                PLAT = 10000,
            };

            db.Zaposleni.Add(newD);
        }

        private void GenerateAdmin(ProjectModelContainer db, string v)
        {
            Admin newA = new Admin
            {
                Id = v,
                D_ZAP = DateTime.Now,
                PLAT = 18000,
                NPR = "A1"
            };

            db.Zaposleni.Add(newA);
        }

        private void AssignRooms(ProjectModelContainer db)
        {
            var teams = db.Timovi.Where(x => x.Programeri.Count > 0).ToList();

            for(int i = 0; i < teams.Count; ++i)
            {
                var programeri = teams[i].Programeri.ToList();
                foreach(var programer in programeri)
                {
                    programer.PoslovniProstor = db.PoslovniProstori.Find("PP" + i);
                }
            }
        }

        private void AssignTeamLeads(ProjectModelContainer db)
        {
            var teams = db.Timovi.Where(x => x.Programeri.Count > 0).ToList();
            
            foreach(Tim team in teams)
            {
                var programeri = team.Programeri.ToList();
                team.VodjaTima = programeri.First();
            }
        }

        private void AssignProgramerToTeam(ProjectModelContainer db, string programerId, string teamId)
        {
            Programer prog = (Programer)db.Zaposleni.Find(programerId);
            prog.ClanTima = db.Timovi.Find(teamId);
        }

        private void GenerateProgramer(ProjectModelContainer db, string programerID)
        {
            Programer newProgramer = new Programer
            {
                Id = programerID,
                D_ZAP = DateTime.Now,
                O_PROD = 13,
                PLAT = 13000
            };

            db.Zaposleni.Add(newProgramer);
        }

        private void GenerateTim(ProjectModelContainer db, string teamId)
        {
            Tim tim = new Tim
            {
                ST = teamId,
                PR = "Research&Development",
            };

            db.Timovi.Add(tim);  
        }

        private void GeneratePoslovniProstor(ProjectModelContainer db, string roomId)
        {
            PoslovniProstor poslovniProstor = new PoslovniProstor
            {
                SP = roomId,
                DIM = 80.0M,
                BRM = 10
            };

            db.PoslovniProstori.Add(poslovniProstor);
        }

    }
}
