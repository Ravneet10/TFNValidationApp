import React, { Component } from 'react';
import { validateTFN } from './ValidateTFNumberService';
import './Validate.css';

export class ValidateTfnNumber extends Component {

    constructor(props) {
        super(props);
        this.state = {
            tfnNumber: null,
            loading: false,
            isValidatedNumber: null,
            errorMessage: null,
            consecutiveAttemptCount: 0
        };
        this.numberChange = this.numberChange.bind(this);
        this.validate = this.validate.bind(this);
    }

    numberChange(value) {
        this.setState({ tfnNumber: value.target.value, errorMessage: null });
    }
    validate() {
        this.setState({ errorMessage: null });
        this.validateTaxFileNumber(this);
    }
    handleOnClose() {
        this.setState({ errorMessage: null });
    }

    renderForm() {
        return (
            <div>
                {/*<ErrorDialog showModal={this.state.errorMessage!=null} handleOnClose={this.handleOnClose}*/}
                {/*    heading={"Error Dialog"}*/}
                {/*    errorMessage={this.state.errorMessage}*/}
                {/*/>*/}
                <input type="text" pattern="\d*" maxLength="12" onChange={this.numberChange} value={this.tfnNumber} />
                <p className={!this.state.isValidatedNumber? "errorText" :"correctText"} aria-live="polite">
                    <strong>
                        {this.state.tfnNumber != null && this.state.isValidatedNumber != null ? (
                            this.state.isValidatedNumber
                                ? 'Tax File Number is Valid'
                                : this.state.errorMessage) : ''
                        }
                    </strong></p>

                <button className="btn btn-primary" onClick={this.validate} disabled={this.state.loading}>Validate</button>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderForm();

        return (
            <div>
                <h1>Validate Tax File Number</h1>
                <p>This component demonstrates validating Tax File Number.</p>
                {contents}
            </div>
        );
    }
    checkConsecutiveAttempt() {
        if (this.state.consecutiveAttemptCount > 4) {
            this.setState({
                errorMessage: 'Consecutive numbers combination used for Tax File Number in last 30 seconds',
                consecutiveAttemptCount: 0
            })
        }
    }

    setResponseState(data) {
        this.setState({
            isValidatedNumber: data.isValidNumber,
            loading: false,
            errorMessage: !data.isValidNumber ?
                (!this.state.errorMessage? "Tax File Number is not valid" : this.state.errorMessage)
                : "",
            consecutiveAttemptCount: data.isConsecutiveSequence ?
                this.state.consecutiveAttemptCount + 1 : this.state.consecutiveAttemptCount
        })
    }
    setErrorResponseState(data) {
        this.setState({
            isValidatedNumber: false,
            loading: false,
            errorMessage: data.errors && data.errors[0].description,
            consecutiveAttemptCount: data.isConsecutiveSequence ?
                this.state.consecutiveAttemptCount + 1 : this.state.consecutiveAttemptCount
        })
    }
    async validateTaxFileNumber(currentRef) {
        setInterval(this.checkConsecutiveAttempt(), 30000);
        await validateTFN(currentRef, this.state.tfnNumber);
    }
}
