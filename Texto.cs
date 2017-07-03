using System;

namespace Editor
{
    // Classe para o editor de texto
    public class Text
    {
        // Atributos e propriedades
        private ListaDupla listaTexto;
        
        // Retorna a primeira linha do texto
        public Node FirstLine
        {
            get { return listaTexto.FirstNode; }
        }

        // N�mero de linhas do texto
        public int NumLines
        {
            get { return listaTexto.Count; }
        }

        // Construtor
        public Text()
        {
            listaTexto = new ListaDupla();
        }

        // Nova linha: o valor -1 indica que o elemento deve ser 
        // inserido na primeira posi��o
        // Outros valores indicam a posi��o ap�s a qual o novo elmento ser�
        // inserido, ininciando em 0
        public void InsertLine(string text, int position)
        {
            if(position==-1)
                listaTexto.Insert(null, text);
            else
            {
                Node p = listaTexto.FirstNode;

                for(int i =0 ; i<position;i++)
                {
                    p = p.Next;
                }
                listaTexto.Insert(p, text);
            }
                
        }

        // Iniciando em 0, a posi��o da linha que deve ser alterada
        public void ChangeLine(string text, int position)
        {
            Node p = listaTexto.FirstNode;

            for(int i = 0; i < position;i++)
                p = p.Next;

            p.Info = text;
        }

        // Excluindo uma linha - � passada a posi��o da linha comen�ando em zero
        public void RemoveLine(int position)
        {
            Node n = listaTexto.FirstNode;
         
            for (int i = 0; i < position; i++)
            {
                n = n.Next;          
            }
           
            n.Prior.Info += (string)n.Info;
            listaTexto.Remove(n);
        }

        public void DeleteLine(int position)
        {
            Node n = listaTexto.FirstNode;

            for (int i = 0; i < position; i++)
            {
                n = n.Next;
            }

            n.Info += (string)n.Next.Info;
            listaTexto.Delete(n);
        }

    }

}
