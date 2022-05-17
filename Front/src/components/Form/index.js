import React, { useState, setState } from "react";
import connApi from "../../config/connectionAPI";

import "./index.css";

import { Button } from "antd";
import { Input } from "antd";

import useAlert from "../../hooks/useAlert";

function Form({ onAddNewPerson }) {
  const { Alert } = useAlert();
  const [loading, setLoading] = useState(false);
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [age, setAge] = useState(0);

  const handleSubmit = async (event) => {
    event.preventDefault();

    setLoading(true);

    if (!name && !email && !age) {
      Alert(
        "Falha ao inserir esta pessoa! Por favor, verifique as informações e tente novamente.",
        "error"
      );

      setLoading(false);
      return;
    }

    const response = await connApi.post("/Pessoa", {
      nome: name,
      email,
      idade: Number(age),
    });

    const addedPerson = response.data;

    setLoading(false);

    Alert("Pessoa inserida com sucesso!", "success");

    onAddNewPerson(addedPerson);
  };

  return (
    <>
      <form className="form" onSubmit={handleSubmit}>
        <Input
          name="Name"
          type="text"
          placeholder="Digite seu nome"
          size="large"
          value={name}
          onChange={(event) => setName(event.target.value)}
        />

        <Input
          name="Email"
          type="text"
          placeholder="Digite seu email"
          size="large"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
        />

        <Input
          name="Idade"
          type="number"
          placeholder="Digite sua idade"
          size="large"
          value={age}
          onChange={(event) => setAge(event.target.value)}
        />
        <Button size="large" loading={loading} htmlType="submit" type="primary">
          Inserir
        </Button>
      </form>
    </>
  );
}

export default Form;
