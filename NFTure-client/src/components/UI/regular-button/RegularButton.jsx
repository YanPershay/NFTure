import Button from "../Button";
import "./RegularButton.css";

const RegularButton = ({ children, ...props }) => {
  return <Button className="regularButton" {...props}>{children}</Button>;
};

export default RegularButton;
