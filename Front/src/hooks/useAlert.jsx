import { toast } from 'react-toastify';

const useAlert = () => {
    const Alert = (message, alertType) => toast(message, { type: alertType });

    return { Alert };
};

export default useAlert;