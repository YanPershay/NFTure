import GradientButton from "../../components/UI/gradient-button/GradientButton";
import RegularButton from "../../components/UI/regular-button/RegularButton";
import "./Home.css";

const HomePage = () => {
  return (
    <div className="homePage">
      <div className="welcomeText">
        <div className="text">
          Collect & Sell Your <span className="awesomeText">Awesome</span> NFTs
        </div>
        <div className="buttons">
          <GradientButton>Create</GradientButton>
          <RegularButton>Explore</RegularButton>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
