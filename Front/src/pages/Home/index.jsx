import { useEffect, useState, useCallback } from "react/cjs/react.development";
import Form from "../../components/Form";
import Table from "../../components/PeopleList";
import connApi from "../../config/connectionAPI";

import "./index.css";

export const Home = () => {
  const [people, setPeople] = useState([]);

  const handleAddNewPerson = useCallback(
    (person) => {
      setPeople([...people, person]);
    },
    [people]
  );

  const handleRemovePerson = useCallback(
    async (id) => {
      const newPeople = [...people];

      setPeople(people.filter((person) => person.pessoaId !== id));

      try {
        await connApi.delete("/Pessoa", {
          params: {
            id,
          },
        });
      } catch (error) {
        setPeople(newPeople);
      }
    },
    [people]
  );

  useEffect(() => {
    async function getPeople() {
      const response = await connApi.get("/Pessoa");

      setPeople(response.data);
    }

    getPeople();
  }, []);

  return (
    <div className="container">
      <header>
        <h2>Bem-vindo ao cadastro de pessoas!</h2>
      </header>
      <Form onAddNewPerson={handleAddNewPerson} />
      <Table people={people} onRemovePerson={handleRemovePerson} />
    </div>
  );
};
