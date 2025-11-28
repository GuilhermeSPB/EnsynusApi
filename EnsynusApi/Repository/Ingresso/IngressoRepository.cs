using EnsynusApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Repository.Ingresso;
using EnsynusApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using EnsynusApi.Dtos.Ingresso;
using System.Security.Principal;

namespace EnsynusApi.Repository.Ingresso
{
    public class IngressoRepository : IIngressoRepository
    {
        private readonly EnsynusContext _context;


        public IngressoRepository(EnsynusContext context)
        {
            _context = context;
        }


        public async Task<Models.Ingresso> CreateAsync(Models.Ingresso ingresso)
        {
            _context.Ingressos.Add(ingresso);
            await  _context.SaveChangesAsync();
            return ingresso;
        }

        public async Task<Models.Ingresso> DeleteAsync(int id)
        {
            var ingressoExistente = await _context.Ingressos.FindAsync(id);

            if (ingressoExistente == null)
            {
                return null;
            }

            _context.Ingressos.Remove(ingressoExistente);
            await _context.SaveChangesAsync();
            return ingressoExistente;

        }

        public async Task<List<Models.VwIngresso>> GetAllAlunosAsync(int id)
        {
            return await _context.VwIngresso.Where(i => i.AluId == id).ToListAsync();
        }

        public async Task<List<Models.VwIngresso>> GetAllTurmasAsync(int id)
        {
            return await _context.VwIngresso.Where(i => i.TurId == id).ToListAsync();
        }

        //public async Task<List<Models.VwIngresso>> GetAllTurmasAsync(int id)
        //{
        //    return await _context.Ingressos.Where(i => i.FkTurId == id).ToListAsync();
        //}
    }
}
