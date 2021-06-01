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
                }


                //assign all programers to random teams
                for (int i = 0; i < 10; ++i)
                {
                    AddProgramerToTeam(db, "PR" + i, "T" + rand.Next(0,10));
                }

                //assign a team lead to every team that has atleast 1 member
                AssignTeamLeads(db);

                //assign work room to every team member
                AssignRooms(db);

                db.SaveChanges();
                Console.WriteLine("Success");
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
            var teams = db.Timovi.Where(x => x.Programeri.Count > 0);
            
            foreach(Tim team in teams)
            {
                var programeri = team.Programeri.ToList();
                team.VodjaTima = programeri.First();
            }
        }

        private void AddProgramerToTeam(ProjectModelContainer db, string programerId, string teamId)
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
