﻿using iPractice.Domain.Models;

namespace iPractice.Infrastructure
{
    public class SeedData
    {
        private const int NoClients = 50;
        private const int NoPsychologists = 20;

        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            var psychologists = CreatePsychologists();
            _context.Psychologists.AddRange(psychologists);

            var clients = CreateClients(psychologists);
            _context.Clients.AddRange(clients);

            _context.SaveChanges();
        }

        private static List<Client> CreateClients(List<Psychologist> psychologists)
        {
            var random = new Random();

            List<Client> clients = new List<Client>();
            for (int i = 1; i < NoClients; i++)
            {
                var client = new Client(i, $"Client {i}");
                client.AddPsychologist(psychologists.Skip(random.Next(NoPsychologists - 1)).First());
                client.AddPsychologist(psychologists.Skip(random.Next(NoPsychologists - 1)).First());

                clients.Add(client);
            }

            return clients;
        }

        private static List<Psychologist> CreatePsychologists()
        {
            List<Psychologist> psychologists = new List<Psychologist>();
            for (int i = 1; i < NoPsychologists; i++)
            {
                psychologists.Add(new Psychologist(i, $"Psychologist {i}"));
            }

            return psychologists;
        }
    }
}