﻿using DepartAdmin.DAL.Context;
using DepartAdmin.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartAdmin.Sever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinoController : ControllerBase
    {
        #region"Context"

        private readonly DepartAdminContext dbContext;

        public InquilinoController(DepartAdminContext context)
        {
            this.dbContext = context;
        }

        #endregion

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List() 
        {
            var responseApi = new ResponseAPI<List<Inquilino>>();
            var listInquilino = new List<Inquilino>();

            try
            {
                foreach(var item in await dbContext.Inquilino.ToListAsync())
                {
                    listInquilino.Add(new Inquilino
                    {
                        UserId = item.UserId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        NumeroDepartamento = item.NumeroDepartamento,
                        NumeroTelefonico = item.NumeroTelefonico,
                        Cedula = item.Cedula,
                        CreationDate = item.CreationDate
                    });
                }

                responseApi.response = true;
                responseApi.Valor = listInquilino;

            }
            catch (Exception ex)
            {
                responseApi.response = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Search/{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var responseApi = new ResponseAPI<Inquilino>();
            var inquilino = new Inquilino();

            try
            {
                var dbInquilino = await dbContext.Inquilino.FirstOrDefaultAsync(x => x.UserId == id);

                if (dbInquilino is not null)
                {
                    inquilino.UserId = dbInquilino.UserId;
                    inquilino.FirstName = dbInquilino.FirstName;
                    inquilino.LastName = dbInquilino.LastName;
                    inquilino.NumeroDepartamento = dbInquilino.NumeroDepartamento;
                    inquilino.NumeroTelefonico = dbInquilino.NumeroTelefonico;
                    inquilino.Cedula = dbInquilino.Cedula;
                    inquilino.CreationDate = dbInquilino.CreationDate;


                    responseApi.response = true;
                    responseApi.Valor = inquilino;
                }

                else
                {
                    responseApi.response = false;
                    responseApi.Mensaje = "No se encotro el inquilino.";
                }
                

            }
            catch (Exception ex)
            {
                responseApi.response = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(Inquilino inquilino)
        {
            var responseApi = new ResponseAPI<int>();
            

            try
            {
                var dbInquilino = new Inquilino
                {
                    UserId = inquilino.UserId,
                    FirstName = inquilino.FirstName,
                    LastName = inquilino.LastName,
                    NumeroDepartamento = inquilino.NumeroDepartamento,
                    NumeroTelefonico = inquilino.NumeroTelefonico,
                    Cedula = inquilino.Cedula,
                    CreationDate = inquilino.CreationDate
                };

                dbContext.Inquilino.Add(dbInquilino);
                await dbContext.SaveChangesAsync();

                if (dbInquilino.UserId != 0)
                {
                    responseApi.response = true;
                    responseApi.Valor = dbInquilino.UserId;
                }

                else
                {
                    responseApi.response = false;
                    responseApi.Mensaje = "No se pudo guardar el inquilino";
                }
            }
            catch (Exception ex)
            {
                responseApi.response = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Inquilino inquilino, int id)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {
                var dbInquilino = await dbContext.Inquilino.FirstOrDefaultAsync(e => e.UserId == id);
        
                

                if (dbInquilino is not null)
                {
                    dbInquilino.UserId = inquilino.UserId;
                    dbInquilino.FirstName = inquilino.FirstName;
                    dbInquilino.LastName = inquilino.LastName;
                    dbInquilino.NumeroDepartamento = inquilino.NumeroDepartamento;
                    dbInquilino.NumeroTelefonico = inquilino.NumeroTelefonico;
                    dbInquilino.Cedula = inquilino.Cedula;
                    dbInquilino.CreationDate = inquilino.CreationDate;



                    dbContext.Inquilino.Update(dbInquilino);
                    await dbContext.SaveChangesAsync();


                    responseApi.response = true;
                    responseApi.Valor = dbInquilino.UserId;
                }

                else
                {
                    responseApi.response = false;
                    responseApi.Mensaje = "No se pudo encotrar el empleado";
                }
            }
            catch (Exception ex)
            {
                responseApi.response = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {
                var dbInquilino = await dbContext.Inquilino.FirstOrDefaultAsync(e => e.UserId == id);



                if (dbInquilino is not null)
                {
                    dbContext.Inquilino.Remove(dbInquilino);
                    await dbContext.SaveChangesAsync();


                    responseApi.response = true;
                }

                else
                {
                    responseApi.response = false;
                    responseApi.Mensaje = "No se pudo encotrar el empleado";
                }
            }
            catch (Exception ex)
            {
                responseApi.response = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
