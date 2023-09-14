using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EditorRepository: BaseRepository<Editor>
    {
        public override void Update(Editor entity)
        {
            var ctx = new NewsEntities();
            Editor edt = ctx.Editor.FirstOrDefault(x => x.Id == entity.Id);
            edt.Name = entity.Name;
            edt.Surname = entity.Surname;
            edt.UserName = entity.UserName;
            edt.Password = entity.Password;
            edt.ImagesId = entity.ImagesId;
            ctx.SaveChanges();
        }

        public Editor Login(Editor editor)
        {
            Editor edt = new NewsEntities().Editor.FirstOrDefault(x => x.UserName == editor.UserName && x.Password == editor.Password);
            if (edt == null)
            {
                return null;
            }

            return edt;
        }
    }
}
