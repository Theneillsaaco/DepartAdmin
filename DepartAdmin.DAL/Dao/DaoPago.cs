using DepartAdmin.DAL.Context;
using DepartAdmin.DAL.Entities;
using DepartAdmin.DAL.Enums;
using DepartAdmin.DAL.Exceptions;
using DepartAdmin.DAL.Interfaces;
using DepartAdmin.DAL.Models;

namespace DepartAdmin.DAL.Dao
{
    public class DaoPago : IDaoPago
    {
        #region"context"
        private readonly DepartAdminContext context;

        public DaoPago(DepartAdminContext context)
        {
            this.context = context;
        }

        #endregion
        public bool ExtistsPagos(Func<Pago, bool> filter)
        {
            return this.context.Pago.Any(filter);
        }

        public DaoPagoModel? GetPago(int Id)
        {
            DaoPagoModel? daoPagoModel = new DaoPagoModel();
            try
            {
                daoPagoModel = (from Pago in this.context.Pago
                                join depto in this.context.Inquilino
                                           on Pago.UserId
                                           equals depto.UserId
                                where Pago.UserId == Id
                                select new DaoPagoModel()
                                {
                                    UserId = depto.UserId,
                                    FirstName = depto.FirstName,
                                    LastName = depto.LastName,
                                    NumeroDepartamento = depto.NumeroDepartamento,
                                    NumeroDeposito = Pago.NumeroDeposito,
                                    FechaMudanza = Pago.FechaMudanza,
                                    FechaPago = Pago.FechaPago,
                                    MontoPagado = Pago.MontoPagado,
                                    Retrasado = Pago.Retrasado

                                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new DaoPagoException($"Error, no se pudo obtener el inquilino: {ex.Message}.");
            }

            return daoPagoModel;
        }

        public List<DaoPagoModel> GetPagos()
        {
            List<DaoPagoModel>? pagoList = new List<DaoPagoModel>();

            try
            {
                pagoList = (from Pago in this.context.Pago
                            join depto in this.context.Inquilino
                                       on Pago.UserId
                                       equals depto.UserId
                            select new DaoPagoModel()
                            {
                                UserId = depto.UserId,
                                FirstName = depto.FirstName,
                                LastName = depto.LastName,
                                NumeroDepartamento = depto.NumeroDepartamento,
                                NumeroDeposito = Pago.NumeroDeposito,
                                FechaMudanza = Pago.FechaMudanza,
                                FechaPago = Pago.FechaPago,
                                MontoPagado = Pago.MontoPagado,
                                Retrasado = Pago.Retrasado
                            }).ToList();

            }
            catch (Exception ex)
            {

                throw new DaoInquilinoException($"Error, no se pudo obtener el inquilino {ex.Message}.");
            }

            return pagoList;
        }

        public List<DaoPagoModel> GetPagos(Func<Pago, bool> filter)
        {
            List<DaoPagoModel>? pagoList = new List<DaoPagoModel>();

            try
            {
                var pago = this.context.Pago.Where(filter);

                pagoList = (from Pago in this.context.Pago
                            join depto in this.context.Inquilino
                                       on Pago.UserId
                                       equals depto.UserId
                            orderby Pago.UserId ascending
                            select new DaoPagoModel()
                            {
                                UserId = depto.UserId,
                                FirstName = depto.FirstName,
                                LastName = depto.LastName,
                                NumeroDepartamento = depto.NumeroDepartamento,
                                NumeroDeposito = Pago.NumeroDeposito,
                                FechaMudanza = Pago.FechaMudanza,
                                FechaPago = Pago.FechaPago,
                                MontoPagado = Pago.MontoPagado,
                                Retrasado = Pago.Retrasado
                            }).ToList();

            }
            catch (Exception ex)
            {

                throw new DaoInquilinoException($"Error, no se pudo obtener el inquilino {ex.Message}.");
            }

            return pagoList;
        }

        public void RemovePago(Pago pago) { }

        public void SavePago(Pago pago)
        {
            try
            {
                this.context.Pago.Add(pago);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new DaoPagoException(ex.Message);
            }
        }

        public void UpdatePago(Pago pago)
        {
            Pago? pagoToUpdate = this.context.Pago.Find(pago.UserId);

            if (pago is null)
                throw new DaoPagoException("No se encotro el Pago.");

            pagoToUpdate.FechaMudanza = pago.FechaMudanza;
            pagoToUpdate.FechaPago = pago.FechaPago;
            pagoToUpdate.Retrasado = pago.Retrasado;
            pagoToUpdate.MontoPagado = pago.MontoPagado;
            pagoToUpdate.NumeroDeposito = pago.NumeroDeposito;
            pagoToUpdate.UserId = pago.UserId;
            pagoToUpdate.User = pago.User;


            this.context.Pago.Update(pagoToUpdate);
            this.context.SaveChanges();
        }

        #region"Retriciones"

        private bool IsPagoValid(Pago pago, ref string Message, Operations operations)
        {
            bool result = false;

            #region"requerido"

            if (pago.FechaMudanza != null)
            {
                Message = "Se requiere la fecha de la mudanza.";

                return true;
            }

            if (pago.FechaPago != null)
            {
                Message = "Se requiere la fecha del pago.";

                return true;
            }

            if (pago.UserId != null)
            {
                Message = "Se requiere el inquilino.";

                return true;
            }

            if (pago.MontoPagado != null)
            {
                Message = "Se requiere el monto de pago.";

                return true;
            }

            if (pago.NumeroDeposito != null)
            {
                Message = "Se requiere el numero de departamento.";

                return true;
            }

            #endregion

            if (operations == Operations.Save)
            {
                if (this.ExtistsPagos(cd => cd.UserId == pago.UserId))
                {
                    Message = "El inquino ya se encuentra registrado.";

                    return result;
                }

                else
                {
                    result = true;
                }
            }

            else
                result = true;


            return result;
        }

        #endregion
    }
}