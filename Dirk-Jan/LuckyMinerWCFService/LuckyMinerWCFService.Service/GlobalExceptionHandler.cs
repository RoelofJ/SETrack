using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Service
{
    public class GlobalExceptionHandler : IErrorHandler
    {
        // <summary>
        /// The method that's get invoked if any unhandled exception raised in service
        /// Here you can do what ever logic you would like to. 
        /// For example logging the exception details
        /// Here the return value indicates that the exception was handled or not
        /// Return true to stop exception propagation and system considers 
        /// that the exception was handled properly
        /// else return false to abort the session
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool HandleError(Exception error)
        {
            return true;
        }

        /// <summary>
        /// If you want to communicate the exception details to the service client 
        /// as proper fault message
        /// here is the place to do it
        /// If we want to suppress the communication about the exception, 
        /// set fault to null
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            FaultException newEx = null;
               newEx  = new FaultException(
                    string.Format("Exception caught at Service Application GlobalErrorHandler{0}Method: {1} {2} Message: {3}",
                    Environment.NewLine, error.TargetSite.Name,
                    Environment.NewLine, error.Message));

            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
            
        }
    }

    public class GlobalErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        private readonly Type errorHandlerType;

        /// &lt;summary>
        /// Dependency injection to dynamically inject error handler 
        /// if we have multiple global error handlers
        /// &lt;/summary>
        /// &lt;param name="errorHandlerType">&lt;/param>
        public GlobalErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        #region IServiceBehavior Members

        void IServiceBehavior.Validate(ServiceDescription description,
            ServiceHostBase serviceHostBase)
        {
        }

        void IServiceBehavior.AddBindingParameters(ServiceDescription description,ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,  BindingParameterCollection parameters)
        {
        }

    /// &lt;summary>
    /// Registering the instance of global error handler in 
    /// dispatch behavior of the service
    /// &lt;/summary>
    /// &lt;param name="description">&lt;/param>
    /// &lt;param name="serviceHostBase">&lt;/param>
    void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description,
        ServiceHostBase serviceHostBase)
    {
        IErrorHandler errorHandler;

        try
        {
            errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
        }
        catch (MissingMethodException e)
        {
            throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must have a public empty constructor.", e);
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must implement System.ServiceModel.Dispatcher.IErrorHandler.", e);
            }

            foreach (ChannelDispatcherBase channelDispatcherBase in 
            serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }

        #endregion IServiceBehavior Members
    }
}
