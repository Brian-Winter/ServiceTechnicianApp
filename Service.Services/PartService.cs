using Service.Data;
using Service.Model.MachinePartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PartService
    {

        //READ ALL
        public IEnumerable<MachinePartListAll> GetPartsList()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MachineParts
                        .Select(
                          e =>
                            new MachinePartListAll
                            {
                                MachinePartId = e.MachinePartId,
                                PartName = e.PartName,
                                PartNumber = e.PartNumber,
                                Cost = e.Cost
                            }


                        );
                return query.ToArray();
            }
        }
        //READ SINGLE
        public MachinePartDetail GetMachinePartById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .MachineParts
                                .Single(e => e.MachinePartId == id);
                return
                    new MachinePartDetail
                    {
                        MachinePartId = entity.MachinePartId,
                        PartName = entity.PartName,
                        PartNumber = entity.PartNumber,
                        Cost = entity.Cost,
                        NumberInStock = entity.NumberInStock,
                        AvailableToOrder = entity.AvailableToOrder
                    };
            }
        }
        //READ SINGLE BY PART NUMBER
        public MachinePartDetail GetMachinePartByPartNumber(string partNumber)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .MachineParts
                                .Single(e => e.PartNumber == partNumber);
                return new MachinePartDetail
                {
                    MachinePartId = entity.MachinePartId
                };
            }
        }
        //CREATE
        public bool CreatePart(MachinePartCreate model)
        {

            var entity = new MachinePart()
            {
                
                PartNumber = model.PartNumber,
                PartName = model.PartName,
                Cost = model.Cost,
                AvailableToOrder = model.AvailableToOrder
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.MachineParts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //EDIT
        public bool EditMachinePart(MachinePartEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .MachineParts
                                .Single(e => e.MachinePartId == model.MachinePartId);

                entity.PartName = model.PartName;
                entity.PartNumber = model.PartNumber;
                entity.Cost = model.Cost;
                entity.NumberInStock = model.NumberInStock;
                entity.AvailableToOrder = model.AvailableToOrder;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
