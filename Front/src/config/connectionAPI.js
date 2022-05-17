import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:48224",
  headers: { "Access-Control-Allow-Origin": "*" },
});
