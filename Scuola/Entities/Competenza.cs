using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Competenza
    {   
        // PROPRIETA'
        public long Id { get; set; }
        public string Note { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long PersonaId { get; set; }
        public long SkillId { get; set; }
        public long LivelloId { get; set; }
        public Persona Persona { get; set; }
        public Skill Skill { get; set; }
        public Livello Livello { get; set; }



        //COSTRUTTORI
        public Competenza(long id, string note, long personaId, long skillId, long livelloId)
        {
            Id = id;
            Note = note;
            PersonaId = personaId;
            SkillId = skillId;
            LivelloId = livelloId;
        }

        public Competenza()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Note: {Note} ";
        }

    }
}
