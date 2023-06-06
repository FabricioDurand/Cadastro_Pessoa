import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:30749",
  headers: { "Access-Control-Allow-Origin": "*" },
});
