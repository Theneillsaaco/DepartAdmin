using DepartAdmin.DAL.Interfaces;
using DepartAdmin.DAL.Entities;
using DepartAdmin.DAL.Enums;
using DepartAdmin.DAL.Exceptions;
using DepartAdmin.DAL.Context;

namespace DepartAdmin.DAL.Dao
{
    public class DaoInquilino : IDaoInquilino
    {
        #region"context"
        private readonly DepartAdminContext context;

        public DaoInquilino(DepartAdminContext context)
        {
            this.context = context;
        }

        #endregion

        public bool ExtistsInquilinos(Func<Inquilino, bool> filter)
        {
            return this.context.Inquilino.Any(filter);
        }

        public Inquilino? GetInquilino(int Id)
        {
            return this.context.Inquilino.Find(Id);
        }

        public List<Inquilino> GetInquilinos()
        {
            var querry = (from depto in context.Inquilino
                          where depto.Deleted == false
                          orderby depto.CreationDate descending
                          select depto).ToList();


            return querry;
        }

        public List<Inquilino> GetInquilinos(Func<Inquilino, bool> filter)
        {
            return this.context.Inquilino.Where(filter).ToList();
        }

        public void RemoveInquilino(Inquilino inquilino)
        {
            Inquilino? inquilinoToRemove = this.GetInquilino(inquilino.UserId);

            inquilinoToRemove.Deleted = inquilino.Deleted;
            inquilinoToRemove.DeletedDate = inquilino.DeletedDate;
            inquilinoToRemove.UserDeleted = inquilino.UserDeleted;


            this.context.Inquilino.Update(inquilinoToRemove);
            this.context.SaveChanges();
        }

        public void SaveInquilino(Inquilino inquilino)
        {
            string Message = string.Empty;


            if (!IsInquilinoValid(inquilino, ref Message, Operations.Save))
                throw new DaoInquilinoException(Message);


            this.context.Inquilino.Add(inquilino);
            this.context.SaveChanges();
        }

        public void UpdateInquilino(Inquilino inquilino)
        {
            string Message = string.Empty;


            if (!IsInquilinoValid(inquilino, ref Message, Operations.Save))
                throw new DaoInquilinoException(Message);


            Inquilino? inquilinoToUpdate = this.GetInquilino(inquilino.UserId);

            if (inquilinoToUpdate is null)
                throw new DaoInquilinoException("No se pudo encontrar el inquilino");

            inquilinoToUpdate.ModifyDate = inquilino.ModifyDate;
            inquilinoToUpdate.FirstName = inquilino.FirstName;
            inquilinoToUpdate.LastName = inquilino.LastName;
            inquilinoToUpdate.NumeroDepartamento = inquilino.NumeroDepartamento;
            inquilinoToUpdate.NumeroTelefonico = inquilino.NumeroTelefonico;
            inquilinoToUpdate.Cedula = inquilino.Cedula;
            inquilinoToUpdate.UserMod = inquilino.UserMod;


            this.context.Inquilino.Update(inquilinoToUpdate);
            this.context.SaveChanges();
        }

        #region"Retriciones"

        private bool IsInquilinoValid(Inquilino inquilino, ref string Message, Operations operations)
        {
            bool result = false;

            #region"requerido"

            if (string.IsNullOrEmpty(inquilino.FirstName))
            {
                Message = "El nombre del inquilino es requerido.";

                return true;
            }

            if (string.IsNullOrEmpty(inquilino.LastName))
            {
                Message = "El apellido del inquilino es requerido.";

                return true;
            }

            if (string.IsNullOrEmpty(inquilino.Cedula))
            {
                Message = "La cedula es requerido.";

                return true;
            }

            if (string.IsNullOrEmpty(inquilino.NumeroTelefonico))
            {
                Message = "El numero de Telefono es requerido.";

                return true;
            }

            if (inquilino.NumeroDepartamento != null)
            {
                Message = "El numero de Departamento es requerido.";

                return true;
            }

            if (inquilino.FirstName.Length > 50)
            {
                Message = "El nombre es demaciado largo, el limite es 50 caracteres.";

                return true;
            }

            if (inquilino.LastName.Length > 50)
            {
                Message = "El apellido es demaciado largo, el limite es 50 caracteres.";

                return true;
            }

            if (inquilino.Cedula.Length > 11)
            {
                Message = "La cedula es demaciado largo, el limite es 11 caracteres.";

                return true;
            }

            if (inquilino.NumeroTelefonico.Length > 15)
            {
                Message = "El numero de Telefono es demaciado largo, el limite es 15 caracteres.";

                return true;
            }

            #endregion

            if (operations == Operations.Save)
            {
                if (this.ExtistsInquilinos(cd => cd.Cedula == inquilino.Cedula))
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