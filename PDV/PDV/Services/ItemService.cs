using PDV.Models;
using PDV.Repository;
using PDV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Services
{
    public class ItemService
    {
        private readonly ItemRepository itemRepository;

        public ItemService(ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<ItemViewModel> GetById(long Id)
        {
            try
            {
                ItemViewModel itemViewModel = new ItemViewModel(await itemRepository.GetById(Id));
                return itemViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<ItemViewModel>> GetList()
        {
            try
            {
                List<ItemViewModel> ListaItens = new List<ItemViewModel>();

                IEnumerable<Item> Itens = await itemRepository.GetList();
                foreach (Item item in Itens)
                {
                    ListaItens.Add(new ItemViewModel(item));
                }

                return ListaItens;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(ItemViewModel itemViewModel)
        {
            try
            {
                Item item = MotarItem(itemViewModel);

                return await itemRepository.Insert(item);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Remove(long Id)
        {
            try
            {
                await itemRepository.Remove(Id);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(ItemViewModel itemViewModel)
        {
            try
            {
                Item item = MotarItem(itemViewModel);

                await itemRepository.Update(item);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Item MotarItem(ItemViewModel itemViewModel)
        {
            try
            {
                Item item = new Item()
                {
                    Data = itemViewModel.Data,
                    Id = itemViewModel.Id,
                    Nome = itemViewModel.Nome,
                    Valor = itemViewModel.Valor
                };

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
