import Routes from './routes'

import 'antd/dist/antd.css';
import './styles/global.css';
import 'react-toastify/dist/ReactToastify.css';

import { ToastContainer } from 'react-toastify';
 
function App() {

  return (
    <>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      /> <Routes />
    </>
  );
}

export default App;