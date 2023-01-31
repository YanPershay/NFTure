import "./GradientButton.css";
import Button from "../Button";

const GradientButton = ({ children, ...props }) => {
  return <Button className="gradientButton"{...props}>{children}</Button>;
};

export default GradientButton;
