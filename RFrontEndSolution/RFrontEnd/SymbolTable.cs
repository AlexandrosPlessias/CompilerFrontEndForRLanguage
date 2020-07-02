using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Antlr4.Runtime.Atn;

namespace RFrontEnd
{
    class SymbolTable
    {
        private Stack<String> m_enviromentNamesStack;
        private List<String> m_allEnviroments;
        private Dictionary<KeyValuePair<string,string>,string> m_symbolTable; // Symbol Table with: <Key (is symbol_name)  , Value (is enviroment_name)>, Typification (Local,Param,Free)>
        private KeyValuePair<string, string> m_lastEnviromentElement;
        private bool returnFlag;

        public SymbolTable() {
            m_enviromentNamesStack = new Stack<string>();
            m_allEnviroments = new List<string>();
            m_symbolTable = new Dictionary<KeyValuePair<string, string>, string>();
            m_lastEnviromentElement = new KeyValuePair<string, string>();
            returnFlag = false;
        }

        public void EnterEnviroment(string envName)
        {

            if (envName == "Global")
            {
                m_enviromentNamesStack.Push(envName);
                m_allEnviroments.Add(envName);
            }
            else
            {
                // Always the function name is the last assigment.
                // Get the function name
                string name = m_lastEnviromentElement.Key;

                // Push current enviroment name to stack.
                m_enviromentNamesStack.Push(name);
                m_allEnviroments.Add(name);

                // Remove the last entry beacause is function not a value.
                m_symbolTable.Remove(m_lastEnviromentElement);
            }

        }

        public void LeaveEnviroment()
        {
            // Pop the enviroment name becaise i'm leaving.
            m_enviromentNamesStack.Pop();

        }

        public void AddSymbol(string symbolName, string typification) {

            string currentEnv = m_enviromentNamesStack.Peek();

            // Extra safety for accepting only ID type nodes.
            if (!symbolName.Contains("ID"))
            {
                return;
            }

            // Clean the name from label stuffs.
            string symbolNameTemp = Regex.Replace(symbolName, "NT_ID_[0-9]+< ", "");
            string symbolNameTemp2 = symbolNameTemp.Replace(">", "");
            string realName = symbolNameTemp2.Trim();

            m_lastEnviromentElement = new KeyValuePair<string, string>(realName, currentEnv);


            // Check if already exist the pair (value,enviroment)
            if (m_symbolTable.Keys.Contains(m_lastEnviromentElement))
            {
                return;
            }

            // If is Local or Param
            if (typification != "Check Type")
            {
                m_symbolTable.Add(m_lastEnviromentElement, typification);
            }
            else
            {

                // Manage the return's call.
                if (returnFlag)
                {
                    returnFlag = false;
                    return;
                }

                if (realName == "return")
                {
                    returnFlag = true;
                    return;
                }

                string typificationOfFree = null;
                KeyValuePair<string, string> freeSymbol = new KeyValuePair<string, string>();

                // Check if have Function (for funtion vs valiable)
                if (m_allEnviroments.Contains(realName))
                {
                    typificationOfFree = "Funtion Call";
                    freeSymbol = new KeyValuePair<string, string>(realName, currentEnv);

                    // Chech if exist already!!!
                    if (m_symbolTable.ContainsKey(freeSymbol)) { return; }

                    m_symbolTable.Add(freeSymbol, typificationOfFree);
                    return;
                }

                // Search in others scope.
                foreach (var otherScopes in m_symbolTable.Keys.ToList()){

                    // Add free symbol if exist in other scope
                    if (otherScopes.Key == realName)
                      {
                           typificationOfFree = "Free ( Exists in " + otherScopes.Value + ")";
                           freeSymbol = new KeyValuePair<string, string>(realName, currentEnv);

                            // Chech if exist already!!!
                            if (m_symbolTable.ContainsKey(freeSymbol)) { return; }

                            m_symbolTable.Add(freeSymbol, typificationOfFree);

                     }
                     else  // Add free symbol if exist in system's scope
                     {
                           typificationOfFree = "Free (System)";
                           freeSymbol = new KeyValuePair<string, string>(realName, currentEnv);

                           // Chech if exist already!!!
                           if (m_symbolTable.ContainsKey(freeSymbol)) { return; }

                      }   

                }

                // Chech if exist already!!!
                if (m_symbolTable.ContainsKey(freeSymbol)) { return; }
                m_symbolTable.Add(freeSymbol, typificationOfFree);

            }
        }

        public void WriteToFile(StreamWriter mOutputStream)
        {
            using (mOutputStream)
            {
                mOutputStream.WriteLine("Scope           | Variable        | Typification     ");
                mOutputStream.WriteLine("-----------------------------------------------------");
                foreach (var currentRecord in m_symbolTable )
                {
                    mOutputStream.WriteLine("{0,-15} | {1,-15} | {2,-15} ", currentRecord.Key.Value, currentRecord.Key.Key, currentRecord.Value);

                }
                mOutputStream.WriteLine("-----------------------------------------------------");

            }


        }
    }
}
