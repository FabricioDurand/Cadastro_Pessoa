import React, { memo } from "react";

import "./index.css";

import { Table } from "antd";

function PeopleList({ people, onRemovePerson }) {
  const columns = [
    {
      title: "ID",
      dataIndex: "pessoaId",
      key: "pessoaId",
    },

    {
      title: "Nome",
      dataIndex: "nome",
      key: "nome",
    },
    {
      title: "Email",
      dataIndex: "email",
      key: "email",
    },
    {
      title: "Age",
      dataIndex: "age",
      key: "age",
    },
    {
      title: "Actions",
      dataIndex: "actions",
      key: "actions",
      render: (_, person) => (
        <button onClick={() => onRemovePerson(person.pessoaId)}>Remove</button>
      ),
    },
  ];

  const dataSource = people.map((item) => {
    return {
      key: item.pessoaId,
      pessoaId: item.pessoaId,
      nome: item.nome,
      email: item.email,
      age: item.idade,
    };
  });

  return <Table className="table" dataSource={dataSource} columns={columns} />;
}

export default PeopleList;
